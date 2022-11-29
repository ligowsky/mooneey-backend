using Mooneey.Domain;

namespace Mooneey.Application;

public interface IExpenseRepository
{
    Task<Expense> CreateAsync(ExpenseCreateRequest request);
}