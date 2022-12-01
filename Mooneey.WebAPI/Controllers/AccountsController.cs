using Microsoft.AspNetCore.Mvc;
using Mooneey.Application;
using Mooneey.Presentation;

namespace Mooneey.WebAPI.Controllers;

[ApiController]
[Route("api/v1/accounts")]
public class AccountsController : Controller
{
    private readonly IAccountRepository _accountRrepository;
    private readonly ITransactionRepository _transactionRepository;

    public AccountsController(IAccountRepository accountRepository, ITransactionRepository transactionRepository)
    {
        _accountRrepository = accountRepository;
        _transactionRepository = transactionRepository;
    }

    [HttpGet(Name = "GetAllAccounts")]
    public async Task<IActionResult> GetAllAsync()
    {
        var accounts = await _accountRrepository.GetAllAsync();
        var result = accounts.Select(AccountViewModel.FromDomain);

        return Ok(result);
    }

    [HttpGet("{id:guid}", Name = "GetAccount")]
    public async Task<IActionResult> GetAsync([FromRoute] Guid id)
    {
        var account = await _accountRrepository.GetAsync(id);
        var result = AccountViewModel.FromDomain(account);

        return Ok(result);
    }

    [HttpPost(Name = "CreateAccount")]
    public async Task<IActionResult> CreateAsync([FromBody] AccountCreateRequestViewModel request)
    {
        var account = request.ToDomain();
        var createdAccount = await _accountRrepository.CreateAsync(account);
        var result = AccountViewModel.FromDomain(createdAccount);

        return CreatedAtRoute("GetAccount", new { result.Id }, result);
    }

    [HttpPut("{id:guid}", Name = "UpdateAccount")]
    public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] AccountUpdateRequestViewModel request)
    {
        var account = request.ToDomain();
        var updatedAccount = await _accountRrepository.UpdateAsync(id, account);
        var result = AccountViewModel.FromDomain(updatedAccount);

        return Ok(result);
    }

    [HttpDelete("{id:guid}", Name = "DeleteAccount")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        await _accountRrepository.DeleteAsync(id);

        return Ok();
    }
    
    [HttpGet("{id:guid}/transactions", Name = "GetTransactions")]
    public async Task<IActionResult> GetTransactions([FromRoute] Guid id)
    {
        var transactions = await _transactionRepository.GetAllAsync(id);
        var result = transactions.Select(TransactionViewModel.FromDomain);

        return Ok(result);
    }
}