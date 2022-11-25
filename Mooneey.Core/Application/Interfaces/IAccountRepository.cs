using System;
using Mooneey.Core.Models.Entities;

namespace Mooneey.Core.Interfaces
{
	public interface IAccountRepository
	{
		Task<List<Account>> GetAllAsync();
		Task<Account> GetByIdAsync(Guid id);
		Task<Account> CreateAsync(Account account);
        Task<Account> UpdateAsync(Guid id, Account account);
        Task DeleteAsync(Guid id);
	}
}

