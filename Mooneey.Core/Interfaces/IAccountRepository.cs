using System;
using Mooneey.Core.Models.Entities;
using Mooneey.Core.Models.Requests;

namespace Mooneey.Core.Interfaces
{
	public interface IAccountRepository
	{
		Task<List<Account>> GetAccountsAsync();
		Task<Account> GetAccountAsync(Guid accountId);
		Task<Account> CreateAccountAsync(AccountCreateRequest account);
        Task<Account> UpdateAccountAsync(Guid accountId, AccountUpdateRequest account);
        Task DeleteAccountAsync(Guid accountId);
	}
}

