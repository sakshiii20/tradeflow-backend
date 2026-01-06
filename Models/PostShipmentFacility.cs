namespace backend.Models
{
    public class PostShipmentFacility
    {
        public string FacilityRef { get; set; } = $"PSF-{DateTime.UtcNow.Ticks}";
        public string FacilityType { get; set; } = "";
        public string Customer { get; set; } = "";
        public string LcReference { get; set; } = "";
        public decimal BillAmount { get; set; }
        public decimal AdvanceAmount { get; set; }
        public string Currency { get; set; } = "";
        public decimal InterestRate { get; set; }
        public DateTime? DueDate { get; set; }
        public string Status { get; set; } = "Draft";
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }
}
