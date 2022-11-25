using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mooneey.Core.Interfaces;
using Mooneey.Presentation.ViewModels.Entity;
using Mooneey.Presentation.ViewModels.Request;

namespace Mooneey.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/accounts")]
    public class AccountsController : Controller
    {
        private readonly IAccountRepository _repository;

        public AccountsController(IAccountRepository repository)
        {
            _repository = repository;
        }

        [HttpGet(Name = "GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _repository.GetAccountsAsync();
            var accounts = result.Select(account => AccountViewModel.FromDomain(account));

            return Ok(accounts);
        }

        [HttpGet("{id:guid}", Name = "GetById")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var account = await _repository.GetAccountAsync(id);
            var result = AccountViewModel.FromDomain(account);

            return Ok(result);
        }

        [HttpPost(Name = "Create")]
        public async Task<IActionResult> CreateAsync([FromBody] AccountCreateRequest request)
        {
            var account = AccountCreateRequest.ToDomain(request);
            var createdAccount = await _repository.CreateAccountAsync(account);
            var result = AccountViewModel.FromDomain(createdAccount);

            return CreatedAtRoute("GetById", new { Id = result.Id }, result);
        }
    }
}

