using Mooneey.Domain;

namespace Mooneey.Application;

public interface ITransferRepository
{
    Task<Transfer> CreateAsync(Transfer transfer);
}