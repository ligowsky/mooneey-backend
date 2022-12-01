using Mooneey.Domain;

namespace Mooneey.Application;

public interface ITransactionRepository
{
    Task<IEnumerable<Transaction>> GetAllAsync(Guid accountId);
    Task<Transaction> GetAsync(Guid id);

    Task<Income> CreateIncomeAsync(IncomeCreateRequest request);
    Task<Income> UpdateIncomeAsync(Guid incomeId, IncomeUpdateRequest request);
    Task DeleteIncomeAsync(Guid incomeId);
    
    Task<Expense> CreateExpenseAsync(ExpenseCreateRequest request);
    Task<Income> UpdateExpenseAsync(Guid expenseId, ExpenseUpdateRequest request);
    Task DeleteExpenseAsync(Guid expenseId);
}