namespace backend.DTOs;

public class CreatePreShipmentDto
{
    public string Customer { get; set; } = "";
    public string LcReference { get; set; } = "";
    public decimal Amount { get; set; }
    public string Currency { get; set; } = "";
    public decimal InterestRate { get; set; }
    public int TenorDays { get; set; }
    public DateTime DisbursementDate { get; set; }
    public DateTime DueDate { get; set; }
}
