using Mooneey.Domain;

namespace Mooneey.Presentation;

public class TransferDetailsViewModel
{
    public Guid? SourceAccountId { get; set; }
    public string? SourceAccountName { get; set; }
    public decimal? SourceAmount { get; set; }
    public CurrencyCode? SourceCurrencyCode { get; set; }
    public Guid? TargetAccountId { get; set; }
    public string? TargetAccountName { get; set; }
    public decimal? TargetAmount { get; set; }
    public CurrencyCode? TargetCurrencyCode { get; set; }
    
    public static TransferDetailsViewModel FromDomain(Transfer input) => new()
    {
        SourceAccountId = input.SourceAccountId,
        SourceAccountName = input.SourceAccount?.Name,
        SourceAmount = input.SourceAmount,
        SourceCurrencyCode = input.SourceAccount?.CurrencyCode,
        TargetAccountId = input.TargetAccountId,
        TargetAccountName = input.TargetAccount?.Name,
        TargetAmount = input.TargetAmount,
        TargetCurrencyCode = input.TargetAccount?.CurrencyCode,
    };
}