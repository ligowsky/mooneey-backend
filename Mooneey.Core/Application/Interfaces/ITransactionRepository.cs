using Mooneey.Core.Domain.Models.Entities;

namespace Mooneey.Core.Application.Interfaces;

public interface ITransactionRepository
{
    Task<List<Transaction>> GetAllAsync();
    Task<Transaction> GetByIdAsync(Guid id);
    Task<Transaction> CreateAsync(Transaction transaction);
    Task<Transaction> UpdateAsync(Guid id, Transaction transaction);
    Task DeleteAsync(Guid id);
}