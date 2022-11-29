using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Mooneey.Presentation.Validation;

namespace Mooneey.Presentation.Extensions;

public static class AddValidationExtension
{
    public static IServiceCollection AddValidation(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<AccountCreateRequestValidator>();
        services.AddValidatorsFromAssemblyContaining<AccountUpdateRequestValidator>();
        
        services.AddValidatorsFromAssemblyContaining<CategoryCreateRequestValidator>();
        services.AddValidatorsFromAssemblyContaining<CategoryUpdateRequestValidator>();
        
        services.AddValidatorsFromAssemblyContaining<TransactionCreateRequestValidator>();
        services.AddValidatorsFromAssemblyContaining<TransactionUpdateRequestValidator>();
        
        services.AddFluentValidationAutoValidation();
        services.AddTransient<IValidatorInterceptor, ValidationInterceptor>();

        return services;
    }
}