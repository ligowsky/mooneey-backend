using Mooneey.Domain;

namespace Mooneey.Application;

public interface IIncomeRepository
{
    Task<Income> CreateAsync(IncomeCreateRequest request);
}