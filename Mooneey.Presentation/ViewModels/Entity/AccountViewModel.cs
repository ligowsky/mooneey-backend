using System.Text.Json.Serialization;
using Mooneey.Core.Domain.Enums;
using Mooneey.Core.Domain.Models.Entities;

namespace Mooneey.Presentation.ViewModels.Entity;

public class AccountViewModel
{
    [JsonPropertyName("id")] 
    public Guid Id { get; set; }

    [JsonPropertyName("type")] 
    public AccountTypeEnum AccountType { get; set; }

    [JsonPropertyName("name")] 
    public string? Name { get; set; }

    [JsonPropertyName("currency")] 
    public CurrencyEnum Currency { get; set; }

    [JsonPropertyName("balance")] 
    public decimal Balance { get; set; }

    [JsonPropertyName("createdAt")] 
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("updatedAt")] 
    public DateTime UpdatedAt { get; set; }

    public static AccountViewModel FromDomain(Account account) => new()
    {
        Id = account.Id,
        AccountType = account.AccountType,
        Name = account.Name,
        Currency = account.Currency,
        Balance = account.Balance,
        CreatedAt = account.CreatedAt,
        UpdatedAt = account.UpdatedAt
    };
}