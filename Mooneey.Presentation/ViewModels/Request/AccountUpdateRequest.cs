using System.Text.Json.Serialization;
using Mooneey.Core.Domain.Enums;
using Mooneey.Core.Domain.Models.Entities;

namespace Mooneey.Presentation.ViewModels.Request;

public class AccountUpdateRequest
{
    [JsonPropertyName("id")] 
    public Guid Id { get; }

    [JsonPropertyName("type")] 
    public AccountTypeEnum AccountType { get; }

    [JsonPropertyName("name")] 
    public string? Name { get; }

    [JsonPropertyName("currency")] 
    public CurrencyEnum Currency { get; }

    [JsonPropertyName("balance")] 
    public decimal Balance { get; }

    public static Account ToDomain(AccountUpdateRequest account) => new()
    {
        Id = account.Id,
        AccountType = account.AccountType,
        Name = account.Name,
        Currency = account.Currency,
        Balance = account.Balance
    };
}