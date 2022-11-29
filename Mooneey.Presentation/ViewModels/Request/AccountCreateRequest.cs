using System.Text.Json.Serialization;
using Mooneey.Core.Domain.Enums;
using Mooneey.Core.Domain.Models.Entities;

namespace Mooneey.Presentation.ViewModels.Request;

public class AccountCreateRequest
{
	[JsonPropertyName("type")]
	public AccountTypeEnum AccountType { get; set; }

	[JsonPropertyName("currency")]
	public CurrencyEnum Currency { get; set; }
	
	[JsonPropertyName("name")]
	public string? Name { get; set; }
	
	[JsonPropertyName("balance")]
	public decimal Balance { get; set; }

	public static Account ToDomain(AccountCreateRequest account) => new()
	{
		AccountType = account.AccountType,
		Currency = account.Currency,
		Name = account.Name,
		Balance = account.Balance,
	};
}