using Microsoft.AspNetCore.Mvc;
using Mooneey.Application;
using Mooneey.Presentation;
using Mooneey.Presentation.ViewModels.Entity;

namespace Mooneey.WebAPI.Controllers;

[ApiController]
[Route("api/v1/transactions")]
public class TransactionsController : Controller
{
    private readonly ITransactionRepository _repository;

    public TransactionsController(ITransactionRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("{accountId:guid}", Name = "GetAll")]
    public async Task<IActionResult> GetAllAsync([FromRoute] Guid accountId)
    {
        var transactions = await _repository.GetAllAsync(accountId);
        var result = transactions.Select(TransactionViewModel.FromDomain);

        return Ok(result);
    }

    [HttpGet("{id:guid}", Name = "GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var transaction = await _repository.GetAsync(id);
        var result = TransactionViewModel.FromDomain(transaction);

        return Ok(result);
    }

    [HttpDelete("{id:guid}", Name = "Delete")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);

        return Ok();
    }
}