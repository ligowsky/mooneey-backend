using Mooneey.Domain;

namespace Mooneey.Presentation;

public class IncomeUpdateRequestViewModel
{
    public decimal? Amount { get; set; }
    public DateTime? Timestamp { get; set; }
    public string? Comment { get; set; } 

    public IncomeUpdateRequest ToDomain() => new()
    {
        Amount = Amount,
        Timestamp = Timestamp,
        Comment = Comment
    };
}