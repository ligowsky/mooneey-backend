using BitzArt;
using Mooneey.Domain;

namespace Mooneey.Presentation;

public class IncomeDetailsViewModel
{
    public Guid AccountId { get; set; }
    public decimal Amount { get; set; }
    public CurrencyCode CurrencyCode { get; set; }
    
    public static IncomeDetailsViewModel FromDomain(Income input) => new()
    {
        AccountId = input.AccountId,
        Amount = input.Amount,
        CurrencyCode = input.Account!.CurrencyCode,
    };
}