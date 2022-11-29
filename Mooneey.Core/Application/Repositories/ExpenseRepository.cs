using Microsoft.EntityFrameworkCore;
using Mooneey.Domain;
using BitzArt;

namespace Mooneey.Application.Repositories;

public class ExpenseRepository : RepositoryBase, IExpenseRepository
{
    public ExpenseRepository(AppDbContext db) : base(db)
    {
    }

    public async Task<Expense> CreateAsync(ExpenseCreateRequest request)
    {
        var account = await _db.Set<Account>()
            .Where(a => a.Id == request.AccountId)
            .FirstOrDefaultAsync();

        if (account is null) throw ApiException.BadRequest($"Account with id = '{request.AccountId}' was not found.");

        var expense = new Expense(account, request.Amount);

        await _db.AddAsync(expense);

        await _db.SaveChangesAsync();

        return expense;
    }
}