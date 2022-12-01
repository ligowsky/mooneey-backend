using Microsoft.AspNetCore.Mvc;
using Mooneey.Application;
using Mooneey.Presentation;

namespace Mooneey.WebAPI.Controllers;

[ApiController]
[Route("api/v1/accounts")]
public class AccountsController : Controller
{
    private readonly IAccountRepository _accountRepository;
    private readonly ITransactionRepository _transactionRepository;

    public AccountsController(IAccountRepository accountRepository, ITransactionRepository transactionRepository)
    {
        _accountRepository = accountRepository;
        _transactionRepository = transactionRepository;
    }

    [HttpGet(Name = "GetAllAccounts")]
    public async Task<IActionResult> GetAllAsync()
    {
        var accounts = await _accountRepository.GetAllAsync();
        var result = accounts.Select(AccountViewModel.FromDomain);

        return Ok(result);
    }

    [HttpGet("{id:guid}", Name = "GetAccount")]
    public async Task<IActionResult> GetAsync([FromRoute] Guid id)
    {
        var account = await _accountRepository.GetAsync(id);
        var result = AccountViewModel.FromDomain(account);

        return Ok(result);
    }

    [HttpPost(Name = "CreateAccount")]
    public async Task<IActionResult> CreateAsync([FromBody] AccountCreateRequestViewModel request)
    {
        var account = request.ToDomain();
        var createdAccount = await _accountRepository.CreateAsync(account);
        var result = AccountViewModel.FromDomain(createdAccount);

        return CreatedAtRoute("GetAccount", new { result.Id }, result);
    }

    [HttpPut("{id:guid}", Name = "UpdateAccount")]
    public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] AccountUpdateRequestViewModel request)
    {
        var account = request.ToDomain();
        var updatedAccount = await _accountRepository.UpdateAsync(id, account);
        var result = AccountViewModel.FromDomain(updatedAccount);

        return Ok(result);
    }

    [HttpDelete("{id:guid}", Name = "DeleteAccount")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        await _accountRepository.DeleteAsync(id);

        return Ok();
    }
    
    [HttpGet("{id:guid}/transactions", Name = "GetTransactions")]
    public async Task<IActionResult> GetTransactions([FromRoute] Guid id)
    {
        var transactions = await _transactionRepository.GetTransactionsAsync(id);
        var result = transactions.Select(TransactionViewModel.FromDomain);

        return Ok(result);
    }
}