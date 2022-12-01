using Microsoft.AspNetCore.Mvc;
using Mooneey.Application;
using Mooneey.Presentation;

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

    [HttpGet("{id:guid}", Name = "GetTransaction")]
    public async Task<IActionResult> GetTransactionAsync(Guid id)
    {
        var transaction = await _repository.GetTransactionAsync(id);
        var result = TransactionViewModel.FromDomain(transaction);

        return Ok(result);
    }
    
    [HttpDelete("{id:guid}", Name = "DeleteTransaction")]
    public async Task<IActionResult> DeleteTransactionAsync([FromRoute] Guid id)
    {
        await _repository.DeleteTransactionAsync(id);

        return Ok();
    }
}