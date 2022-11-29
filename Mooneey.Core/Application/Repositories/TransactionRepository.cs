using BitzArt;
using Microsoft.EntityFrameworkCore;
using Mooneey.Domain;

namespace Mooneey.Application.Repositories;

public class TransactionRepository : RepositoryBase, ITransactionRepository
{
    public TransactionRepository(AppDbContext db) : base(db)
    {
    }

    public async Task<IEnumerable<Transaction>> GetAllAsync(Guid accountId)
    {
        var isAccountExists = await _db.Set<Account>()
            .Where(a => a.Id == accountId)
            .AnyAsync();

        if (!isAccountExists)
        {
            throw ApiException.NotFound($"Account with id = '{accountId}' was not found.");
        }

        var transactions = await _db.Set<Account>()
            .Where(x => x.Id == accountId)
            .SelectMany(x => x.Transactions!)
            .ToListAsync();

        return transactions;
    }

    public async Task<Transaction> GetAsync(Guid transactionId)
    {
        var transaction = await _db.Set<Transaction>()
            .Where(t => t.Id == transactionId)
            .IncludeAll()
            .FirstOrDefaultAsync();

        if (transaction is null)
        {
            throw new Exception($"Transaction with id = '{transactionId}' was not found.");
        }

        return transaction;
    }

    public async Task DeleteAsync(Guid transactionId)
    {
        var transaction = await _db.Set<Transaction>()
            .Where(t => t.Id == transactionId)
            .IncludeAll()
            .FirstOrDefaultAsync();

        if (transaction is null)
        {
            throw new Exception($"Transaction with id = '{transactionId}' was not found.");
        }

        transaction.Revert();

        await _db.SaveChangesAsync();
    }
}