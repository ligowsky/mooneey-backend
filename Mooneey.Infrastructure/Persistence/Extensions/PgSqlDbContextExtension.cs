using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mooneey.Core.Contexts;
using Mooneey.Infrastructure.Persistence.Contexts;

namespace Mooneey.Infrastructure.Persistence.Extensions
{
    public static class PgSqlDbContextExtension
    {
        public static IServiceCollection AddPgSqlDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PgSqlDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("Mooneey"),
                x =>
                {
                    x.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                }));

            services.AddScoped<AppDbContext>(x => x.GetRequiredService<PgSqlDbContext>());

            return services;
        }
    }
}

