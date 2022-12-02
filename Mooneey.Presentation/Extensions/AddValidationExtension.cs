using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Mooneey.Presentation.Validation;

namespace Mooneey.Presentation.Extensions;

public static class AddValidationExtension
{
    public static void AddValidation(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<AccountCreateRequestValidator>();
        services.AddValidatorsFromAssemblyContaining<AccountUpdateRequestValidator>();
        
        services.AddFluentValidationAutoValidation();
        services.AddTransient<IValidatorInterceptor, ValidatorInterceptor>();
    }
}


