using BitzArt;
using Microsoft.EntityFrameworkCore;
using Mooneey.Domain;

namespace Mooneey.Application.Repositories;

public class TransactionRepository : RepositoryBase, ITransactionRepository
{
    public TransactionRepository(AppDbContext db) : base(db)
    {
    }

    public async Task<IEnumerable<Transaction>> GetTransactionsAsync(Guid accountId)
    {
        var isAccountExists = await _db.Set<Account>()
            .Where(a => a.Id == accountId)
            .AnyAsync();

        if (!isAccountExists) throw ApiException.NotFound($"Account with id = '{accountId}' was not found.");

        var transactions = await _db.Set<Account>()
            .Where(x => x.Id == accountId)
            .SelectMany(x => x.Transactions!)
            .IncludeAccounts()
            .ToListAsync();

        return transactions;
    }

    public async Task<Transaction> GetTransactionAsync(Guid transactionId)
    {
        var transaction = await _db.Set<Transaction>()
            .Where(t => t.Id == transactionId)
            .IncludeAccounts()
            .FirstOrDefaultAsync();

        if (transaction is null)
            throw ApiException.NotFound($"Transaction with id = '{transactionId}' was not found.");

        return transaction;
    }

    public async Task DeleteTransactionAsync(Guid transactionId)
    {
        var existingTransaction = await _db.Set<Transaction>()
            .Where(t => t.Id == transactionId)
            .IncludeAccounts()
            .FirstOrDefaultAsync();

        if (existingTransaction is null)
            throw ApiException.NotFound($"Transaction with id = '{transactionId}' was not found.");

        existingTransaction.Revert();

        _db.Remove(existingTransaction);

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

        if (existingIncome is null) throw ApiException.NotFound($"Income with id = '{incomeId}' was not found.");

        existingIncome.Update(request);

        await _db.SaveChangesAsync();

        return existingIncome;
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

    public async Task<Expense> UpdateExpenseAsync(Guid expenseId, ExpenseUpdateRequest request)
    {
        var existingExpense = await _db.Set<Expense>()
            .Where(a => a.Id == expenseId)
            .Include(x => x.Account)
            .FirstOrDefaultAsync();

        if (existingExpense is null) throw ApiException.NotFound($"Expense with id = '{expenseId}' was not found.");

        existingExpense.Update(request);

        await _db.SaveChangesAsync();

        return existingExpense;
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
            throw ApiException.NotFound($"Transfer with id = '{transferId}' was not found.");

        existingTransfer.Update(request);

        await _db.SaveChangesAsync();

        return existingTransfer;
    }
}