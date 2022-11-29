using Microsoft.EntityFrameworkCore;
using Mooneey.Core.Application.Contexts;
using Mooneey.Core.Application.Interfaces;
using Mooneey.Core.Domain.Models.Entities;
using BitzArt;

namespace Mooneey.Core.Application.Repositories;

public class TransferRepository : RepositoryBase, ITransferRepository
{
    public TransferRepository(AppDbContext db) : base(db)
    {
    }

    public async Task<List<Transfer>> GetAllAsync()
    {
        var transfers = await _db.Set<Transfer>()
            .Include(t => t.Account)
            .Include(t => t.ToAccount)
            .ToListAsync();

        return transfers;
    }

    public async Task<Transfer> GetByIdAsync(Guid id)
    {
        var transfer = await _db.Set<Transfer>()
            .Where(t => t.Id == id)
            .Include(t => t.Account)
            .Include(t => t.ToAccount)
            .FirstOrDefaultAsync();

        if (transfer is null)
        {
            throw ApiException.BadRequest($"Transfer with id = '{id}' was not found.");
        }

        return transfer;
    }

    public async Task<Transfer> CreateAsync(Transfer transfer)
    {
        var account = await _db.Set<Account>()
            .Where(a => a.Id == transfer.AccountId)
            .FirstOrDefaultAsync();

        if (account is null)
        {
            throw ApiException.BadRequest($"Account with id = '{transfer.AccountId}' was not found.");
        }

        var toAccount = await _db.Set<Account>()
            .Where(a => a.Id == transfer.ToAccountId)
            .FirstOrDefaultAsync();

        if (toAccount is null)
        {
            throw ApiException.BadRequest($"Account with id = '{transfer.ToAccountId}' was not found.");
        }

        transfer.CreatedAt = DateTime.UtcNow;
        transfer.UpdatedAt = DateTime.UtcNow;

        await _db.Set<Transfer>().AddAsync(transfer);

        var outcomeDelta = transfer.GetAmount(account.Id);
        account.UpdateBalance(outcomeDelta);

        var incomeDelta = transfer.GetAmount(toAccount.Id);
        toAccount.UpdateBalance(incomeDelta);

        await _db.SaveChangesAsync();

        return transfer;
    }

    public async Task<Transfer> UpdateAsync(Guid id, Transfer transfer)
    {
        var existingTransfer = await _db.Set<Transfer>()
            .Where(t => t.Id == id)
            .FirstOrDefaultAsync();

        if (existingTransfer is null)
        {
            throw ApiException.BadRequest($"Transfer with id = '{id}' was not found.");
        }

        existingTransfer.OutcomeAmount = transfer.OutcomeAmount;
        existingTransfer.IncomeAmount = transfer.IncomeAmount;
        existingTransfer.Comment = transfer.Comment;
        existingTransfer.TransferDate = transfer.TransferDate;
        existingTransfer.UpdatedAt = DateTime.UtcNow;

        var account = await _db.Set<Account>()
            .Where(a => a.Id == existingTransfer.AccountId)
            .FirstOrDefaultAsync();

        if (account != null)
        {
            var outcomeDelta = transfer.GetAmount(account.Id) - existingTransfer.GetAmount(account.Id);
            account.UpdateBalance(outcomeDelta);
        }

        var toAccount = await _db.Set<Account>()
            .Where(a => a.Id == existingTransfer.ToAccountId)
            .FirstOrDefaultAsync();

        if (toAccount != null)
        {
            var incomeDelta = transfer.GetAmount(toAccount.Id) - existingTransfer.GetAmount(toAccount.Id);
            toAccount.UpdateBalance(incomeDelta);
        }

        await _db.SaveChangesAsync();

        return existingTransfer;
    }

    public async Task DeleteAsync(Guid id)
    {
        var existingTransfer = await _db.Set<Transfer>()
            .Where(t => t.Id == id)
            .FirstOrDefaultAsync();

        if (existingTransfer is null)
        {
            throw ApiException.BadRequest($"Transfer with id = '{id}' was not found.");
        }

        var account = await _db.Set<Account>()
            .Where(a => a.Id == existingTransfer.AccountId)
            .FirstOrDefaultAsync();

        if (account != null)
        {
            var outcomeDelta = -existingTransfer.GetAmount(account.Id);
            account.UpdateBalance(outcomeDelta);
        }

        var toAccount = await _db.Set<Account>()
            .Where(a => a.Id == existingTransfer.ToAccountId)
            .FirstOrDefaultAsync();

        if (toAccount != null)
        {
            var incomeDelta = -existingTransfer.GetAmount(toAccount.Id);
            toAccount.UpdateBalance(incomeDelta);
        }

        _db.Set<Transfer>().Remove(existingTransfer);

        await _db.SaveChangesAsync();
    }
}