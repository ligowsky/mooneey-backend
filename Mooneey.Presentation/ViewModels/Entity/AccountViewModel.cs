using System.Text.Json.Serialization;
using Mooneey.Domain;

namespace Mooneey.Presentation.ViewModels.Entity;

public class AccountViewModel
{
    [JsonPropertyName("id")] 
    public Guid? Id { get; set; }

    [JsonPropertyName("accountType")] 
    public AccountType? AccountType { get; set; }

    [JsonPropertyName("name")] 
    public string? Name { get; set; }

    [JsonPropertyName("currencyCode")] 
    public CurrencyCode? CurrencyCode { get; set; }

    [JsonPropertyName("balance")] 
    public decimal? Balance { get; set; }

    [JsonPropertyName("createdAt")] 
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("updatedAt")] 
    public DateTime? UpdatedAt { get; set; }

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
    
    public Account ToDomain() => new()
    {
        AccountType = AccountType!.Value,
        CurrencyCode = CurrencyCode!.Value,
        Name = Name,
        Balance = Balance!.Value,
    };
}