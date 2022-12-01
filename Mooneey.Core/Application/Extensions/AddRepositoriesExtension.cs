using Microsoft.Extensions.DependencyInjection;
using Mooneey.Application;
using Mooneey.Application.Repositories;

namespace Mooneey;

public static class AddRepositoriesExtension
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IAccountRepository, AccountRepository>();
        services.AddTransient<ITransactionRepository, TransactionRepository>();
    }
}