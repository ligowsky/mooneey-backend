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
            .IncludeAccounts()
            .ToListAsync();

        return transactions;
    }

    public async Task<Transaction> GetAsync(Guid transactionId)
    {
        var transaction = await _db.Set<Transaction>()
            .Where(t => t.Id == transactionId)
            .IncludeAccounts()
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
            .IncludeAccounts()
            .FirstOrDefaultAsync();

        if (transaction is null)
        {
            throw new Exception($"Transaction with id = '{transactionId}' was not found.");
        }

        transaction.Revert();

        await _db.SaveChangesAsync();
    }

    public async Task<Income> CreateIncomeAsync(IncomeCreateRequest request)
    {
        var account = await _db.Set<Account>()
            .Where(a => a.Id == request.AccountId)
            .FirstOrDefaultAsync();

        if (account is null) throw ApiException.BadRequest($"Account with id = '{request.AccountId}' was not found.");

        var income = new Income(account, request.Amount, request.Timestamp, request.Comment);

        await _db.AddAsync(income);

        income.Apply();

        await _db.SaveChangesAsync();

        return income;
    }

    public async Task<Income> UpdateIncomeAsync(Guid incomeId, IncomeUpdateRequest request)
    {
        var existingIncome = await _db.Set<Income>()
            .Where(a => a.Id == incomeId)
            .Include(x => x.Account)
            .FirstOrDefaultAsync();

        if (existingIncome is null) throw ApiException.BadRequest($"Income with id = '{incomeId}' was not found.");

        existingIncome.Revert();

        existingIncome.Amount = request.Amount ?? existingIncome.Amount;
        existingIncome.Timestamp = request.Timestamp ?? existingIncome.Timestamp;
        existingIncome.Comment = request.Comment ?? existingIncome.Comment;
        existingIncome.UpdatedAt = DateTime.UtcNow;

        existingIncome.Apply();

        await _db.SaveChangesAsync();

        return existingIncome;
    }

    public async Task DeleteIncomeAsync(Guid incomeId)
    {
        var existingIncome = await _db.Set<Income>()
            .Where(x => x.Id == incomeId)
            .Include(x => x.Account)
            .FirstOrDefaultAsync();

        if (existingIncome is null) throw ApiException.BadRequest($"Income with id = '{incomeId}' was not found.");

        existingIncome.Revert();

        await _db.SaveChangesAsync();

        _db.Remove(existingIncome);

        await _db.SaveChangesAsync();
    }

    public async Task<Expense> CreateExpenseAsync(ExpenseCreateRequest request)
    {
        var account = await _db.Set<Account>()
            .Where(a => a.Id == request.AccountId)
            .FirstOrDefaultAsync();

        if (account is null) throw ApiException.BadRequest($"Account with id = '{request.AccountId}' was not found.");

        var expense = new Expense(account, request.Amount, request.Timestamp, request.Comment);

        await _db.AddAsync(expense);

        expense.Apply();

        await _db.SaveChangesAsync();

        return expense;
    }

    public async Task<Income> UpdateExpenseAsync(Guid expenseId, ExpenseUpdateRequest request)
    {
        var existingExpense = await _db.Set<Income>()
            .Where(a => a.Id == expenseId)
            .Include(x => x.Account)
            .FirstOrDefaultAsync();

        if (existingExpense is null) throw ApiException.BadRequest($"Expense with id = '{expenseId}' was not found.");

        existingExpense.Revert();

        existingExpense.Amount = request.Amount ?? existingExpense.Amount;
        existingExpense.Timestamp = request.Timestamp ?? existingExpense.Timestamp;
        existingExpense.Comment = request.Comment ?? existingExpense.Comment;
        existingExpense.UpdatedAt = DateTime.UtcNow;

        existingExpense.Apply();

        await _db.SaveChangesAsync();

        return existingExpense;
    }

    public async Task DeleteExpenseAsync(Guid expenseId)
    {
        var existingExpense = await _db.Set<Expense>()
            .Where(x => x.Id == expenseId)
            .Include(x => x.Account)
            .FirstOrDefaultAsync();

        if (existingExpense is null) throw ApiException.BadRequest($"Expense with id = '{expenseId}' was not found.");

        existingExpense.Revert();

        await _db.SaveChangesAsync();

        _db.Remove(existingExpense);

        await _db.SaveChangesAsync();
    }

    public async Task<Transfer> CreateTransferAsync(TransferCreateRequest request)
    {
        var sourceAccount = await _db.Set<Account>()
            .Where(a => a.Id == request.SourceAccountId)
            .FirstOrDefaultAsync();

        if (sourceAccount is null)
            throw ApiException.BadRequest($"Account with id = '{request.SourceAccountId}' was not found.");

        var targetAccount = await _db.Set<Account>()
            .Where(a => a.Id == request.TargetAccountId)
            .FirstOrDefaultAsync();

        if (targetAccount is null)
            throw ApiException.BadRequest($"Account with id = '{request.TargetAccountId}' was not found.");


        var transfer = new Transfer(sourceAccount, targetAccount, request.SourceAmount, request.TargetAmount,
            request.Timestamp, request.Comment);

        await _db.AddAsync(transfer);

        transfer.Apply();

        await _db.SaveChangesAsync();

        return transfer;
    }

    public async Task<Transfer> UpdateTransferAsync(Guid transferId, TransferUpdateRequest request)
    {
        var existingTransfer = await _db.Set<Transfer>()
            .Where(a => a.Id == transferId)
            .Include(x => x.SourceAccount)
            .Include(x => x.TargetAccount)
            .FirstOrDefaultAsync();

        if (existingTransfer is null)
            throw ApiException.BadRequest($"Transfer with id = '{transferId}' was not found.");

        existingTransfer.Revert();

        existingTransfer.SourceAmount = request.SourceAmount ?? existingTransfer.SourceAmount;
        existingTransfer.TargetAmount = request.TargetAmount ?? existingTransfer.TargetAmount;
        existingTransfer.Timestamp = request.Timestamp ?? existingTransfer.Timestamp;
        existingTransfer.Comment = request.Comment ?? existingTransfer.Comment;
        existingTransfer.UpdatedAt = DateTime.UtcNow;

        existingTransfer.Apply();

        await _db.SaveChangesAsync();

        return existingTransfer;
    }

    public async Task DeleteTransferAsync(Guid transferId)
    {
        var existingTransfer = await _db.Set<Transfer>()
            .Where(x => x.Id == transferId)
            .Include(x => x.SourceAccount)
            .Include(x => x.TargetAccount)
            .FirstOrDefaultAsync();

        if (existingTransfer is null)
            throw ApiException.BadRequest($"Transfer with id = '{transferId}' was not found.");

        existingTransfer.Revert();

        await _db.SaveChangesAsync();

        _db.Remove(existingTransfer);

        await _db.SaveChangesAsync();
    }
}