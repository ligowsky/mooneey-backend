using Microsoft.EntityFrameworkCore;
using Mooneey.Domain;
using BitzArt;

namespace Mooneey.Core.Application.Repositories;
/*
public class TransferRepository : RepositoryBase, ITransferRepository
{
    public TransferRepository(AppDbContext db) : base(db)
    {
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
        

        await _db.Set<Transfer>().AddAsync(transfer);

        await _db.SaveChangesAsync();

        return transfer;
    }
}
*/