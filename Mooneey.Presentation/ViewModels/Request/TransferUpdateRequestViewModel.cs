using Mooneey.Domain;

namespace Mooneey.Presentation;

public class TransferUpdateRequestViewModel
{
    public decimal SourceAmount { get; set; }
    public decimal TargetAmount { get; set; }
    public DateTime Timestamp { get; set; }
    public string? Comment { get; set; }

    public TransferUpdateRequest ToDomain() => new()
    {
        SourceAmount = SourceAmount,
        TargetAmount = TargetAmount,
        Timestamp = Timestamp,
        Comment = Comment
    };
}