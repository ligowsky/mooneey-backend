namespace Mooneey.Domain;

public class ExpenseCreateRequest
{
    public Guid AccountId { get; set; }
    public decimal Amount { get; set; }
    public DateTime Timestamp { get; set; }
    public string? Comment { get; set; }
}