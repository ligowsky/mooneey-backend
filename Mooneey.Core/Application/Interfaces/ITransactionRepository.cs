using Mooneey.Domain;

namespace Mooneey.Application;

public interface ITransactionRepository
{
    Task<IEnumerable<Transaction>> GetAllAsync(Guid accountId);
    Task<Transaction> GetAsync(Guid id);
    Task DeleteAsync(Guid id);
}