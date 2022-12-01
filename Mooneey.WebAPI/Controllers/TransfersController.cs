using Microsoft.AspNetCore.Mvc;
using Mooneey.Application;
using Mooneey.Presentation;

namespace Mooneey.WebAPI.Controllers;

[ApiController]
[Route("api/v1/transfers")]
public class TransfersController : Controller
{
    private readonly ITransactionRepository _repository;

    public TransfersController(ITransactionRepository repository)
    {
        _repository = repository;
    }

    [HttpPost(Name = "CreateTransfer")]
    public async Task<IActionResult> CreateTransferAsync([FromBody] TransferCreateRequestViewModel request)
    {
        var transfer = request.ToDomain();
        var createdTransfer = await _repository.CreateTransferAsync(transfer);
        var result = TransactionViewModel.FromDomain(createdTransfer);

        return Ok(result);
    }

    [HttpPut("{id:guid}", Name = "UpdateTransfer")]
    public async Task<IActionResult> UpdateIncomeAsync([FromRoute] Guid id,
        [FromBody] TransferUpdateRequestViewModel request)
    {
        var transfer = request.ToDomain();
        var updatedTransfer = await _repository.UpdateTransferAsync(id, transfer);
        var result = TransactionViewModel.FromDomain(updatedTransfer);

        return Ok(result);
    }
}