namespace Mooneey.Domain;

public class TransferCreateRequest
{
   public Guid SourceAccountId { get; set; }
   public decimal SourceAmount { get; set; }
   public Guid TargetAccountId { get; set; }
   public decimal TargetAmount { get; set; }
   public DateTime Timestamp { get; set; }
   public string? Comment { get; set; }
}