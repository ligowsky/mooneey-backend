using Microsoft.AspNetCore.Mvc;
using Mooneey.Application;
using Mooneey.Presentation;

namespace Mooneey.WebAPI.Controllers;

[ApiController]
[Route("api/v1/income")]
public class IncomeController : Controller
{
    private readonly ITransactionRepository _repository;

    public IncomeController(ITransactionRepository repository)
    {
        _repository = repository;
    }

    [HttpPost(Name = "CreateIncome")]
    public async Task<IActionResult> CreateIncomeAsync([FromBody] IncomeCreateRequestViewModel request)
    {
        var income = request.ToDomain();
        var createdIncome = await _repository.CreateIncomeAsync(income);
        var result = TransactionViewModel.FromDomain(createdIncome);

        return Ok(result);
    }

    [HttpPut("{id:guid}", Name = "UpdateIncome")]
    public async Task<IActionResult> UpdateIncomeAsync([FromRoute] Guid id,
        [FromBody] IncomeUpdateRequestViewModel request)
    {
        var income = request.ToDomain();
        var updatedIncome = await _repository.UpdateIncomeAsync(id, income);
        var result = TransactionViewModel.FromDomain(updatedIncome);

        return Ok(result);
    }
}