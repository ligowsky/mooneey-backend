using Mooneey.Domain;

namespace Mooneey.Presentation;

public class ExpenseDetailsViewModel
{
    public Guid AccountId { get; set; }
    public decimal Amount { get; set; }
    public CurrencyCode CurrencyCode { get; set; }
    
    public static ExpenseDetailsViewModel FromDomain(Expense input) => new()
    {
        AccountId = input.AccountId,
        Amount = input.Amount,
        CurrencyCode = input.Account!.CurrencyCode,
    };
}