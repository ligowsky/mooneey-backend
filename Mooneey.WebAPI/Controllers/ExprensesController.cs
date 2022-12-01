using Microsoft.AspNetCore.Mvc;
using Mooneey.Application;
using Mooneey.Presentation;

namespace Mooneey.WebAPI.Controllers;

[ApiController]
[Route("api/v1/exprenses")]
public class ExpensesController : Controller
{
    private readonly ITransactionRepository _repository;

    public ExpensesController(ITransactionRepository repository)
    {
        _repository = repository;
    }

    [HttpPost(Name = "CreateExpense")]
    public async Task<IActionResult> CreateExpenseAsync([FromBody] ExpenseCreateRequestViewModel request)
    {
        var expense = request.ToDomain();
        var createdExpense = await _repository.CreateExpenseAsync(expense);
        var result = TransactionViewModel.FromDomain(createdExpense);

        return Ok(result);
    }

    [HttpPut("{id:guid}", Name = "UpdateExpense")]
    public async Task<IActionResult> UpdateExpenseAsync([FromRoute] Guid id,
        [FromBody] ExpenseUpdateRequestViewModel request)
    {
        var expense = request.ToDomain();
        var updatedExpense = await _repository.UpdateExpenseAsync(id, expense);
        var result = TransactionViewModel.FromDomain(updatedExpense);

        return Ok(result);
    }
}