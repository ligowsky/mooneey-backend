using System;
using System.Text.Json.Serialization;
using Mooneey.Core.Enums;
using Mooneey.Core.Models.Entities;

namespace Mooneey.Presentation.ViewModels.Request
{
	public class AccountUpdateRequest
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

        public static Account ToDomain(AccountUpdateRequest account) => new()
        {
            Id = account.Id,
            AccountType = account.AccountType,
            Name = account.Name,
            Currency = account.Currency,
            Balance = account.Balance
        };
    }
}

