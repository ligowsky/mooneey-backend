using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mooneey.Infrastructure.Persistence.Extensions;

namespace Mooneey.Infrastructure.Extensions;

public static class InfrastructureExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPgSqlDbContext(configuration);
    }
}