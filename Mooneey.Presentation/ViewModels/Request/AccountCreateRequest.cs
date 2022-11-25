using System.Text.Json.Serialization;
using Mooneey.Core.Domain.Enums;
using Mooneey.Core.Domain.Models.Entities;

namespace Mooneey.Presentation.ViewModels.Request;

public class AccountCreateRequest
{
	[JsonPropertyName("type")]
	public AccountTypeEnum AccountType { get; set; }

	[JsonPropertyName("name")]
	public string? Name { get; set; }

	[JsonPropertyName("currency")]
	public CurrencyEnum Currency { get; set; }

	[JsonPropertyName("balance")]
	public decimal Balance { get; set; }

	public static Account ToDomain(AccountCreateRequest account) => new()
	{
		AccountType = account.AccountType,
		Name = account.Name,
		Currency = account.Currency,
		Balance = account.Balance,
	};
}