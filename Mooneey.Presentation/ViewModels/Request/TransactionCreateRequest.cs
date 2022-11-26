using System.Text.Json.Serialization;
using Mooneey.Core.Domain.Enums;
using Mooneey.Core.Domain.Models.Entities;

namespace Mooneey.Presentation.ViewModels.Request;

public class TransactionCreateRequest
{
	[JsonPropertyName("type")]
	public TransactionTypeEnum TransactionType { get; set; }
	
	[JsonPropertyName("amount")]
	public decimal Amount { get; set; }
	
	[JsonPropertyName("accountId")]
	public Guid AccountId { get; set; }
	
	[JsonPropertyName("categoryId")]
	public Guid CategoryId { get; set; }

	public static Transaction ToDomain(TransactionCreateRequest input) => new()
	{
		TransactionType = input.TransactionType,
		Amount = input.Amount,
		AccountId = input.AccountId,
		CategoryId = input.CategoryId
	};
}