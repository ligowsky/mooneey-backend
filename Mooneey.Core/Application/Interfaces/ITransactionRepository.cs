using Mooneey.Domain;

namespace Mooneey.Application;

public interface ITransactionRepository
{
    Task<IEnumerable<Transaction>> GetTransactionsAsync(Guid accountId);
    Task<Transaction> GetTransactionAsync(Guid id);
    Task DeleteTransactionAsync(Guid id);

    Task<Income> CreateIncomeAsync(IncomeCreateRequest request);
    Task<Income> UpdateIncomeAsync(Guid incomeId, IncomeUpdateRequest request);

    Task<Expense> CreateExpenseAsync(ExpenseCreateRequest request);
    Task<Income> UpdateExpenseAsync(Guid expenseId, ExpenseUpdateRequest request);

    Task<Transfer> CreateTransferAsync(TransferCreateRequest request);
    Task<Transfer> UpdateTransferAsync(Guid transferId, TransferUpdateRequest request);
}