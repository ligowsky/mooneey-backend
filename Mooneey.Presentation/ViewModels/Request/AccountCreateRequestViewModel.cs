using Mooneey.Domain;

namespace Mooneey.Presentation;

public class AccountCreateRequestViewModel
{
    public AccountType AccountType { get; set; }
    public string? Name { get; set; }
    public CurrencyCode CurrencyCode { get; set; }
    public decimal Balance { get; set; }

    public AccountCreateRequest ToDomain() => new()
    {
        AccountType = AccountType,
        CurrencyCode = CurrencyCode,
        Name = Name,
        Balance = Balance,
    };
}