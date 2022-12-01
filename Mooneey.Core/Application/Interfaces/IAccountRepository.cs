using Mooneey.Domain;

namespace Mooneey.Application;

public interface IAccountRepository
{
    Task<IEnumerable<Account>> GetAllAsync();
    Task<Account> GetAsync(Guid id);
    Task<Account> CreateAsync(AccountCreateRequest request);
    Task<Account> UpdateAsync(Guid id, AccountUpdateRequest request);
    Task DeleteAsync(Guid id);
}