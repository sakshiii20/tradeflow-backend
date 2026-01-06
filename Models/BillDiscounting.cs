namespace backend.Models
{
    public class BillDiscounting
    {
        public string Reference { get; set; }
        public string Customer { get; set; }
        public string BillType { get; set; }
        public string BillNumber { get; set; }
        public string Drawee { get; set; }

        public decimal BillAmount { get; set; }
        public decimal DiscountRate { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal NetAmount { get; set; }

        public string Currency { get; set; }
        public DateTime BillDate { get; set; }
        public DateTime MaturityDate { get; set; }

        public string Status { get; set; }   // Draft | Active
        public DateTime CreatedAt { get; set; }
    }
}
