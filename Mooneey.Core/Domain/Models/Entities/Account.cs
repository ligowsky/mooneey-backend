﻿using System;
using Mooneey.Core.Enums;
namespace Mooneey.Core.Models.Entities
{
	public class Account : EntityBase
	{
		public AccountTypeEnum AccountType { get; set; }
		public string? Name {get; set;}
		public CurrencyEnum Currency { get; set; }
		public decimal Balance { get; set; }
	}
}
