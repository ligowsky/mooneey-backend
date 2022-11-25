using System;
using System.Text.Json.Serialization;
using Mooneey.Core.Enums;

namespace Mooneey.Core.Models.Requests
{
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
	}
}

