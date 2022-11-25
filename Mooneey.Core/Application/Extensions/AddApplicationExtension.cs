using System;
using Microsoft.Extensions.DependencyInjection;
using Mooneey.Core.Aoolication.Extensions;
using Mooneey.Core.Interfaces;
using Mooneey.Core.Repositories;

namespace Mooneey.Core.Application.Extensions
{
	public static class AddApplicationExtension
	{
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddRepositories();

            return services;
        }
    }
}

