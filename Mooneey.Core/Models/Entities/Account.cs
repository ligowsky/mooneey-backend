using System;
namespace Mooneey.Core.Models.Entities
{
	public class Account : EntityBase
	{
		public int AccountType { get; set; }
		public string? Name {get; set;}
		public int Currency { get; set; }
		public decimal Balance { get; set; }
	}
}

