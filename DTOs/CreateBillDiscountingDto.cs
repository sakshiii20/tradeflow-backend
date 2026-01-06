namespace backend.DTOs
{
    public class CreateBillDiscountingDto
    {
        public string Customer { get; set; }
        public string BillType { get; set; }
        public string BillNumber { get; set; }
        public string Drawee { get; set; }

        public decimal BillAmount { get; set; }
        public decimal DiscountRate { get; set; }
        public string Currency { get; set; }

        public DateTime BillDate { get; set; }
        public DateTime MaturityDate { get; set; }
    }
}
