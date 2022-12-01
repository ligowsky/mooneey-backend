using Mooneey.Domain;

namespace Mooneey.Presentation;

public class AccountViewModel : EntityBaseAuditableViewModel
{
    public AccountType AccountType { get; set; }
    public string? Name { get; set; }
    public CurrencyCode CurrencyCode { get; set; }
    public decimal Balance { get; set; }

    public static AccountViewModel FromDomain(Account account) => new()
    {
        Id = account.Id,
        AccountType = account.AccountType,
        Name = account.Name,
        CurrencyCode = account.CurrencyCode,
        Balance = account.Balance,
        CreatedAt = account.CreatedAt,
        UpdatedAt = account.UpdatedAt
    };
}