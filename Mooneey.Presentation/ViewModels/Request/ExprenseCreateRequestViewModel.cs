using Mooneey.Domain;

namespace Mooneey.Presentation;

public class ExpenseCreateRequestViewModel
{
    public Guid AccountId { get; set; }
    public decimal Amount { get; set; }
    public DateTime Timestamp { get; set; }
    public string? Comment { get; set; } 

    public ExpenseCreateRequest ToDomain() => new()
    {
        AccountId = AccountId,
        Amount = Amount,
        Timestamp = Timestamp,
        Comment = Comment
    };
}