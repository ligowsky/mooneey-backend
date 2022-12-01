using Microsoft.EntityFrameworkCore;
using Mooneey.Domain;

namespace Mooneey.Application.Repositories;

public class AccountRepository : RepositoryBase, IAccountRepository
{
    public AccountRepository(AppDbContext db) : base(db)
    {
    }

    public async Task<IEnumerable<Account>> GetAllAsync()
    {
        var accounts = await _db.Set<Account>().ToListAsync();

        return accounts;
    }

    public async Task<Account> GetAsync(Guid id)
    {
        var account = await _db.Set<Account>()
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();

        if (account is null) throw new Exception($"Account with id = '{id}' was not found.");

        return account;
    }

    public async Task<Account> CreateAsync(AccountCreateRequest request)
    {
        var account = request.ToEntity();

        await _db.Set<Account>().AddAsync(account);

        await _db.SaveChangesAsync();

        return account;
    }

    public async Task<Account> UpdateAsync(Guid id, AccountUpdateRequest request)
    {
        var existingAccount = await _db.Set<Account>()
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();

        if (existingAccount is null) throw new Exception($"Account with id = '{id}' was not found.");

        existingAccount.AccountType = request.AccountType ?? existingAccount.AccountType;
        existingAccount.CurrencyCode = request.CurrencyCode ?? existingAccount.CurrencyCode;
        existingAccount.Name = request.Name ?? existingAccount.Name;
        existingAccount.Balance = request.Balance ?? existingAccount.Balance;

        await _db.SaveChangesAsync();

        return existingAccount;
    }

    public async Task DeleteAsync(Guid id)
    {
        var existingAccount = await _db.Set<Account>()
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();

        if (existingAccount is null) throw new Exception($"Account with id = '{id}' was not found.");

        _db.Set<Account>().Remove(existingAccount);

        await _db.SaveChangesAsync();
    }
}