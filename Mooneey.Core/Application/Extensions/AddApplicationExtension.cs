using Microsoft.Extensions.DependencyInjection;

namespace Mooneey.Core.Application.Extensions;

public static class AddApplicationExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddRepositories();
    }
}