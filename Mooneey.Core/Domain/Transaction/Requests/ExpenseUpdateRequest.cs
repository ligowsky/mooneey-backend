namespace Mooneey.Domain;

public class ExpenseUpdateRequest
{
    public decimal? Amount { get; set; }
    public DateTime? Timestamp { get; set; }
    public string? Comment { get; set; }
}