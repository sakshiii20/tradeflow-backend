using backend.Models;
using backend.DTOs;

namespace backend.Services;

public class PreShipmentService
{
    private static readonly List<PreShipmentFacility> _facilities = new();

    public List<PreShipmentFacility> GetAll(string? status, string? search)
    {
        var query = _facilities.AsQueryable();

        if (!string.IsNullOrEmpty(status) && status != "all")
            query = query.Where(x => x.Status == status);

        if (!string.IsNullOrEmpty(search))
            query = query.Where(x =>
                x.Customer.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                x.LcReference.Contains(search, StringComparison.OrdinalIgnoreCase)
            );

        return query.ToList();
    }

    public string Create(CreatePreShipmentDto dto, string status)
    {
        var facility = new PreShipmentFacility
        {
            FacilityRef = $"PSF-{DateTime.UtcNow.Ticks}",
            Customer = dto.Customer,
            LcReference = dto.LcReference,
            Amount = dto.Amount,
            Currency = dto.Currency,
            InterestRate = dto.InterestRate,
            TenorDays = dto.TenorDays,
            DisbursementDate = dto.DisbursementDate,
            DueDate = dto.DueDate,
            Status = status
        };

        _facilities.Add(facility);
        return facility.FacilityRef;
    }
}
