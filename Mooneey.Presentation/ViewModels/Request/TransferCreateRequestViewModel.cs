using Mooneey.Domain;

namespace Mooneey.Presentation;

public class TransferCreateRequestViewModel
{
    public Guid SourceAccountId { get; set; }
    public decimal SourceAmount { get; set; }
    public Guid TargetAccountId { get; set; }
    public decimal TargetAmount { get; set; }
    public DateTime Timestamp { get; set; }
    public string? Comment { get; set; } 

    public TransferCreateRequest ToDomain() => new()
    {
        SourceAccountId = SourceAccountId,
        SourceAmount = SourceAmount,
        TargetAccountId = TargetAccountId,
        TargetAmount = TargetAmount,
        Timestamp = Timestamp,
        Comment = Comment
    };
}