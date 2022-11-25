using System;
using Mooneey.Core.Models.Entities;

namespace Mooneey.Core.Interfaces
{
	public interface IAccountRepository
	{
		Task<List<Account>> GetAccountsAsync();
		Task<Account> GetAccountAsync(Guid accountId);
		Task<Account> CreateAccountAsync(Account account);
        Task<Account> UpdateAccountAsync(Guid accountId, Account account);
        Task DeleteAccountAsync(Guid accountId);
	}
}

