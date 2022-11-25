using System;
using Microsoft.Extensions.DependencyInjection;
using Mooneey.Core.Interfaces;
using Mooneey.Core.Repositories;

namespace Mooneey.Core.Aoolication.Extensions
{
    public static class AddRepositoriesExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();

            return services;
        }
    }
}

