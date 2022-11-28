using Microsoft.AspNetCore.Mvc;
using Mooneey.Core.Application.Interfaces;
using Mooneey.Presentation.ViewModels.Entity;
using Mooneey.Presentation.ViewModels.Request;

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

    [HttpGet(Name = "GetAllTransactions")]
    public async Task<IActionResult> GetAllAsync()
    {
        var transactions = await _repository.GetAllAsync();
        var result = transactions.Select(TransactionViewModel.FromDomain);

        return Ok(result);
    }

    [HttpGet("{id:guid}", Name = "GetTransactionById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var transaction = await _repository.GetByIdAsync(id);
        var result = TransactionViewModel.FromDomain(transaction);

        return Ok(result);
    }

    [HttpPost(Name = "CreateTransaction")]
    public async Task<IActionResult> CreateAsync([FromBody] TransactionCreateRequest request)
    {
        var transaction = TransactionCreateRequest.ToDomain(request);
        var createdRecord = await _repository.CreateAsync(transaction);
        var result = TransactionViewModel.FromDomain(createdRecord);

        return CreatedAtRoute("GetTransactionById", new { result.Id }, result);
    }

    [HttpPut("{id:guid}", Name = "UpdateTransaction")]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] TransactionUpdateRequest request)
    {
        var transaction = TransactionUpdateRequest.ToDomain(request);
        var updatedTransaction = await _repository.UpdateAsync(id, transaction);
        var result = TransactionViewModel.FromDomain(updatedTransaction);

        return Ok(result);
    }

    [HttpDelete("{id:guid}", Name = "DeleteTransaction")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);

        return Ok();
    }
}