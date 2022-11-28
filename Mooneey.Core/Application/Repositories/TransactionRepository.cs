using Microsoft.EntityFrameworkCore;
using Mooneey.Core.Application.Contexts;
using Mooneey.Core.Application.Interfaces;
using Mooneey.Core.Domain.Models.Entities;

namespace Mooneey.Core.Application.Repositories;

public class TransactionRepository : RepositoryBase, ITransactionRepository
{
    public TransactionRepository(AppDbContext db) : base(db)
    {
    }

    public async Task<List<Transaction>> GetAllAsync()
    {
        var transactions = await _db.Set<Transaction>()
            .Include(t => t.Account)
            .Include(t => t.Category)
            .ToListAsync();

        return transactions;
    }

    public async Task<Transaction> GetByIdAsync(Guid id)
    {
        var transaction = await _db.Set<Transaction>()
            .Where(t => t.Id == id)
            .Include(t => t.Account)
            .Include(t => t.Category)
            .FirstOrDefaultAsync();

        if (transaction is null)
        {
            throw new Exception($"Transaction with id = '{id}' was not found.");
        }

        return transaction;
    }

    public async Task<Transaction> CreateAsync(Transaction transaction)
    {
        var account = await _db.Set<Account>()
            .Where(a => a.Id == transaction.AccountId)
            .FirstOrDefaultAsync();

        if (account is null)
        {
            throw new Exception($"Account with id = '{transaction.AccountId}' was not found.");
        }

        if (transaction.CategoryId != null)
        {
            var category = await _db.Set<Category>()
                .Where(a => a.Id == transaction.CategoryId)
                .FirstOrDefaultAsync();

            if (category is null)
            {
                throw new Exception($"Category with id = '{transaction.AccountId}' was not found.");
            }
        }

        transaction.CreatedAt = DateTime.UtcNow;
        transaction.UpdatedAt = DateTime.UtcNow;

        await _db.Set<Transaction>().AddAsync(transaction);

        var delta = transaction.GetAmountDelta();
        account.UpdateBalance(delta);

        await _db.SaveChangesAsync();

        return transaction;
    }

    public async Task<Transaction> UpdateAsync(Guid id, Transaction transaction)
    {
        var account = await _db.Set<Account>()
            .Where(a => a.Id == transaction.AccountId)
            .FirstOrDefaultAsync();

        if (account is null)
        {
            throw new Exception($"Account with id = '{transaction.AccountId}' was not found.");
        }

        if (transaction.CategoryId != null)
        {
            var category = await _db.Set<Category>()
                .Where(a => a.Id == transaction.CategoryId)
                .FirstOrDefaultAsync();

            if (category is null)
            {
                throw new Exception($"Category with id = '{transaction.AccountId}' was not found.");
            }
        }

        var existingTransaction = await _db.Set<Transaction>()
            .Where(t => t.Id == id)
            .FirstOrDefaultAsync();

        if (existingTransaction is null)
        {
            throw new Exception($"Transaction with id = '{id}' was not found.");
        }

        var delta = transaction.GetAmountDelta() - existingTransaction.GetAmountDelta();

        existingTransaction.TransactionType = transaction.TransactionType;
        existingTransaction.CategoryId = transaction.CategoryId;
        existingTransaction.Amount = transaction.Amount;
        existingTransaction.Comment = transaction.Comment;
        existingTransaction.UpdatedAt = DateTime.UtcNow;

        account.UpdateBalance(delta);

        await _db.SaveChangesAsync();

        return existingTransaction;
    }

    public async Task DeleteAsync(Guid id)
    {
        var transaction = await _db.Set<Transaction>()
            .Where(t => t.Id == id)
            .FirstOrDefaultAsync();

        if (transaction is null)
        {
            throw new Exception($"Transaction with id = '{id}' was not found.");
        }

        var account = await _db.Set<Account>()
            .Where(t => t.Id == transaction.AccountId)
            .FirstOrDefaultAsync();

        if (account is null)
        {
            throw new Exception($"Account with id = '{transaction.AccountId}' was not found.");
        }

        var delta = -transaction.GetAmountDelta();

        _db.Set<Transaction>().Remove(transaction);

        account.UpdateBalance(delta);

        await _db.SaveChangesAsync();
    }
}