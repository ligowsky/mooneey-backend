using Microsoft.Extensions.DependencyInjection;
using Mooneey.Core.Application.Interfaces;
using Mooneey.Core.Application.Repositories;

namespace Mooneey.Core.Application.Extensions;

public static class AddRepositoriesExtension
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IAccountRepository, AccountRepository>();
        services.AddTransient<ICategoryRepository, CategoryRepository>();
        services.AddTransient<ITransactionRepository, TransactionRepository>();
    }
}