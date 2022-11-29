using Microsoft.AspNetCore.Mvc;
using Mooneey.Application;
using Mooneey.Presentation;
using Mooneey.Presentation.ViewModels.Entity;

namespace Mooneey.WebAPI.Controllers;

[ApiController]
[Route("api/v1/income")]
public class IncomeController : Controller
{
    private readonly IIncomeRepository _repository;

    public IncomeController(IIncomeRepository repository)
    {
        _repository = repository;
    }

    [HttpPost(Name = "Create")]
    public async Task<IActionResult> CreateAsync([FromBody] IncomeCreateRequest request)
    {
        var income = request.ToDomain();
        var createdTransaction = await _repository.CreateAsync(income);
        var result = TransactionViewModel.FromDomain(createdTransaction);

        return Ok(result);
    }

    /*
    [HttpPut("{id:guid}", Name = "Update")]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] IncomeCreateRequest request)
    {
        var income = request.ToDomain();
        var updatedIncome = await _repository.UpdateAsync(id, transaction);
        var result = TransactionViewModel.FromDomain(updatedTransaction);

        return Ok(result);
    }
    */
}