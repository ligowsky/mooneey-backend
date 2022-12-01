using Mooneey.Domain;

namespace Mooneey.Presentation;

public class ExpenseUpdateRequestViewModel
{
    public Guid AccountId { get; set; }
    public decimal Amount { get; set; }
    public DateTime Timestamp { get; set; }
    public string? Comment { get; set; } 

    public ExpenseUpdateRequest ToDomain() => new()
    {
        Amount = Amount,
        Timestamp = Timestamp,
        Comment = Comment
    };
}