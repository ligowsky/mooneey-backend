using Mooneey.Core.Domain.Models.Entities;

namespace Mooneey.Core.Application.Interfaces;

public interface ITransferRepository
{
    Task<List<Transfer>> GetAllAsync();
    Task<Transfer> GetByIdAsync(Guid id);
    Task<Transfer> CreateAsync(Transfer transfer);
    Task<Transfer> UpdateAsync(Guid id, Transfer transfer);
    Task DeleteAsync(Guid id);
}