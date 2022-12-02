using Mooneey.Domain;

namespace Mooneey.Application;

public interface IAccountRepository
{
    Task<IEnumerable<Account>> GetAccountsAsync();
    Task<Account> GetAccountAsync(Guid id);
    Task<Account> CreateAccountAsync(AccountCreateRequest request);
    Task<Account> UpdateAccountAsync(Guid id, AccountUpdateRequest request);
    Task DeleteAccountAsync(Guid id);
}