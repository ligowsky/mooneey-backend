using Microsoft.EntityFrameworkCore;
using Mooneey.Core.Application.Contexts;
using Mooneey.Core.Application.Interfaces;
using Mooneey.Core.Domain.Models.Entities;

namespace Mooneey.Core.Application.Repositories;

public class AccountRepository : RepositoryBase, IAccountRepository
{
    public AccountRepository(AppDbContext db) : base(db)
    {
    }

    public async Task<List<Account>> GetAllAsync()
    {
        var records = await _db.Set<Account>().ToListAsync();

        return records;
    }

    public async Task<Account> GetByIdAsync(Guid id)
    {
        var record = await _db.Set<Account>()
            .Where(a => a.Id == id)
            .FirstOrDefaultAsync();

        if (record is null)
        {
            throw new Exception($"Account with id = '{id}' was not found.");
        }

        return record;
    }

    public async Task<Account> CreateAsync(Account request)
    {
        await _db.Set<Account>().AddAsync(request);
        await _db.SaveChangesAsync();

        return request;
    }

    public async Task<Account> UpdateAsync(Guid id, Account request)
    {
        var record = await _db.Set<Account>()
            .Where(a => a.Id == id)
            .FirstOrDefaultAsync();

        if (record is null)
        {
            throw new Exception($"Account with id = '{id}' was not found.");
        }

        record.AccountType = request.AccountType;
        record.Name = request.Name;
        record.Currency = request.Currency;
        record.Balance = request.Balance;
        record.UpdatedAt = DateTime.UtcNow;

        await _db.SaveChangesAsync();

        return record;
    }

    public async Task DeleteAsync(Guid id)
    {
        var record = await _db.Set<Account>()
            .Where(a => a.Id == id)
            .FirstOrDefaultAsync();

        if (record is null)
        {
            throw new Exception($"Account with id = '{id}' was not found.");
        }

        _db.Set<Account>().Remove(record);
        await _db.SaveChangesAsync();
    }
}