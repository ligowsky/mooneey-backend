using Microsoft.Extensions.DependencyInjection;

namespace Mooneey;

public static class AddApplicationExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddRepositories();
    }
}