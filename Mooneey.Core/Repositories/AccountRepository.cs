﻿using System;
using Microsoft.EntityFrameworkCore;
using Mooneey.Core.Contexts;
using Mooneey.Core.Interfaces;
using Mooneey.Core.Models.Entities;
using Mooneey.Core.Models.Requests;

namespace Mooneey.Core.Repositories
{
    public class AccountRepository : RepositoryBase, IAccountRepository
    {
        public AccountRepository(AppDbContext db) : base(db)
        {
        }

        public async Task<List<Account>> GetAccountsAsync()
        {
            var accounts = await _db.Set<Account>().ToListAsync<Account>();

            return accounts;
        }

        public async Task<Account> GetAccountAsync(Guid accountId)
        {
            var account = await _db.Set<Account>()
                 .Where(a => a.Id == accountId)
                 .FirstOrDefaultAsync();

            if (account is null)
            {
                throw new Exception($"Account with id = '{accountId}' was not found.");
            }

            return account;
        }

        public async Task<Account> CreateAccountAsync(AccountCreateRequest accountCreateRequest)
        {
            var account = new Account()
            {
                AccountType = accountCreateRequest.AccountType,
                Name = accountCreateRequest.Name,
                Currency = accountCreateRequest.Currency,
                Balance = accountCreateRequest.Balance
            };

            await _db.Set<Account>().AddAsync(account);
            await _db.SaveChangesAsync();

            return account;
        }

        public async Task<Account> UpdateAccountAsync(Guid accountId, AccountUpdateRequest accountUpdateRequest)
        {
            var existingAccount = await _db.Set<Account>()
                 .Where(a => a.Id == accountId)
                 .FirstOrDefaultAsync();

            if (existingAccount is null)
            {
                throw new Exception($"Account with id = '{accountId}' was not found.");
            }

            var account = new Account()
            {
                Id = accountUpdateRequest.Id,
                AccountType = accountUpdateRequest.AccountType,
                Name = accountUpdateRequest.Name,
                Currency = accountUpdateRequest.Currency,
                Balance = accountUpdateRequest.Balance
            };

            await _db.Set<Account>().AddAsync(account);
            await _db.SaveChangesAsync();

            return account;
        }

        public async Task DeleteAccountAsync(Guid accountId)
        {
            var account = await _db.Set<Account>()
                .Where(a => a.Id == accountId)
                .FirstOrDefaultAsync();

            if (account is null)
            {
                throw new Exception($"Account with id = '{accountId}' was not found.");
            }

            _db.Set<Account>().Remove(account);
            await _db.SaveChangesAsync();
        }
    }
}

