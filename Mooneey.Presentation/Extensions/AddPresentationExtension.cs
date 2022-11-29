using Microsoft.Extensions.DependencyInjection;

namespace Mooneey.Presentation.Extensions;

public static class AddPresentationExtension
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddValidation();

        return services;
    }
}