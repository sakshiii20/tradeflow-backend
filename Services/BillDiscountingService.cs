using backend.Models;
using backend.DTOs;

namespace backend.Services
{
    public class BillDiscountingService
    {
        private static readonly List<BillDiscounting> _items = new();

        public List<BillDiscounting> GetAll(string status, string search)
        {
            var q = _items.AsQueryable();

            if (!string.IsNullOrEmpty(status) && status != "all")
                q = q.Where(x => x.Status == status);

            if (!string.IsNullOrEmpty(search))
                q = q.Where(x =>
                    x.Reference.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                    x.Customer.Contains(search, StringComparison.OrdinalIgnoreCase));

            return q.OrderByDescending(x => x.CreatedAt).ToList();
        }

        public BillDiscounting Create(CreateBillDiscountingDto dto, string status)
        {
            var days = (dto.MaturityDate - dto.BillDate).Days;
            var discount =
                dto.BillAmount * dto.DiscountRate / 100 * days / 360;

            var item = new BillDiscounting
            {
                Reference = $"BD-{Guid.NewGuid():N}".Substring(0, 10),
                Customer = dto.Customer,
                BillType = dto.BillType,
                BillNumber = dto.BillNumber,
                Drawee = dto.Drawee,
                BillAmount = dto.BillAmount,
                DiscountRate = dto.DiscountRate,
                DiscountAmount = discount,
                NetAmount = dto.BillAmount - discount,
                Currency = dto.Currency,
                BillDate = dto.BillDate,
                MaturityDate = dto.MaturityDate,
                Status = status,
                CreatedAt = DateTime.UtcNow
            };

            _items.Add(item);
            return item;
        }
    }
}
