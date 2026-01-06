using backend.Models;
using backend.DTOs;

namespace backend.Services
{
    public class PostShipmentService
    {
        private static readonly List<PostShipmentFacility> _facilities = new();

        public IEnumerable<PostShipmentFacility> GetAll(string status, string search)
        {
            var q = _facilities.AsQueryable();

            if (!string.IsNullOrEmpty(status) && status != "all")
                q = q.Where(x => x.Status == status);

            if (!string.IsNullOrEmpty(search))
                q = q.Where(x =>
                    x.Customer.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                    x.LcReference.Contains(search, StringComparison.OrdinalIgnoreCase));

            return q.OrderByDescending(x => x.CreatedOn).ToList();
        }

        public void SaveDraft(CreatePostShipmentDto dto)
        {
            _facilities.Add(Map(dto, "Draft"));
        }

        public void Submit(CreatePostShipmentDto dto)
        {
            _facilities.Add(Map(dto, "Active"));
        }

        private PostShipmentFacility Map(CreatePostShipmentDto dto, string status)
        {
            return new PostShipmentFacility
            {
                FacilityType = dto.FacilityType,
                Customer = dto.Customer,
                LcReference = dto.LcReference,
                BillAmount = dto.BillAmount,
                AdvanceAmount = dto.AdvanceAmount,
                Currency = dto.Currency,
                InterestRate = dto.InterestRate,
                DueDate = dto.DueDate,
                Status = status
            };
        }
    }
}
