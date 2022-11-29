using Microsoft.AspNetCore.Mvc;
using Mooneey.Application;
using Mooneey.Presentation.ViewModels.Entity;

namespace Mooneey.WebAPI.Controllers;

[ApiController]
[Route("api/v1/accounts")]
public class AccountsController : Controller
{
    private readonly IAccountRepository _repository;

    public AccountsController(IAccountRepository repository)
    {
        _repository = repository;
    }

    [HttpGet(Name = "GetAllAccounts")]
    public async Task<IActionResult> GetAllAsync()
    {
        var records = await _repository.GetAllAsync();
        var result = records.Select(AccountViewModel.FromDomain);

        return Ok(result);
    }

    [HttpGet("{id:guid}", Name = "GetAccountById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var record = await _repository.GetByIdAsync(id);
        var result = AccountViewModel.FromDomain(record);

        return Ok(result);
    }

    [HttpPost(Name = "CreateAccount")]
    public async Task<IActionResult> CreateAsync([FromBody] AccountViewModel request)
    {
        var record = request.ToDomain();
        var createdRecord = await _repository.CreateAsync(record);
        var result = AccountViewModel.FromDomain(createdRecord);

        return CreatedAtRoute("GetAccountById", new { result.Id }, result);
    }

    [HttpPut("{id:guid}", Name = "UpdateAccount")]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] AccountViewModel request)
    {
        var record = request.ToDomain();
        var updatedRecord = await _repository.UpdateAsync(id, record);
        var result = AccountViewModel.FromDomain(updatedRecord);

        return Ok(result);
    }

    [HttpDelete("{id:guid}", Name = "DeleteAccount")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);

        return Ok();
    }
}