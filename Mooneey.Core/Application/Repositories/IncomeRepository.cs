using Microsoft.EntityFrameworkCore;
using Mooneey.Domain;
using BitzArt;

namespace Mooneey.Application.Repositories;

public class IncomeRepository : RepositoryBase, IIncomeRepository
{
    public IncomeRepository(AppDbContext db) : base(db)
    {
    }

    public async Task<Income> CreateAsync(IncomeCreateRequest request)
    {
        var account = await _db.Set<Account>()
            .Where(a => a.Id == request.AccountId)
            .FirstOrDefaultAsync();

        if (account is null) throw ApiException.BadRequest($"Account with id = '{request.AccountId}' was not found.");

        var income = new Income(account, request.Amount);

        await _db.AddAsync(income);
        
        income.Apply();

        await _db.SaveChangesAsync();

        return income;
    }
}