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
        var records = await _db.Set<Transaction>()
            .Include(r => r.Account)
            .Include(r => r.Category)
            .ToListAsync();

        return records;
    }

    public async Task<Transaction> GetByIdAsync(Guid id)
    {
        var record = await _db.Set<Transaction>()
            .Where(a => a.Id == id)
            .FirstOrDefaultAsync();

        if (record is null)
        {
            throw new Exception($"Transaction with id = '{id}' was not found.");
        }

        return record;
    }

    public async Task<Transaction> CreateAsync(Transaction request)
    {
        request.CreatedAt = DateTime.UtcNow;
        request.UpdatedAt = DateTime.UtcNow;

        await _db.Set<Transaction>().AddAsync(request);
        await _db.SaveChangesAsync();

        return request;
    }

    public async Task<Transaction> UpdateAsync(Guid id, Transaction request)
    {
        var record = await _db.Set<Transaction>()
            .Where(a => a.Id == id)
            .FirstOrDefaultAsync();

        if (record is null)
        {
            throw new Exception($"Transaction with id = '{id}' was not found.");
        }

        record.CategoryId = request.CategoryId;
        record.Amount = request.Amount;
        record.Comment = request.Comment;
        record.UpdatedAt = DateTime.UtcNow;

        await _db.SaveChangesAsync();

        return record;
    }

    public async Task DeleteAsync(Guid id)
    {
        var record = await _db.Set<Transaction>()
            .Where(a => a.Id == id)
            .FirstOrDefaultAsync();

        if (record is null)
        {
            throw new Exception($"Transaction with id = '{id}' was not found.");
        }

        _db.Set<Transaction>().Remove(record);
        await _db.SaveChangesAsync();
    }
}