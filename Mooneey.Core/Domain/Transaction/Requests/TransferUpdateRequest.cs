namespace Mooneey.Domain;

public class TransferUpdateRequest
{
    public decimal? SourceAmount { get; set; }
    public decimal? TargetAmount { get; set; }
    public DateTime? Timestamp { get; set; }
    public string? Comment { get; set; }
}