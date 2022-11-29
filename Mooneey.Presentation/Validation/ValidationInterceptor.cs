using BitzArt;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Mooneey.Presentation.Validation;

public class ValidationInterceptor : IValidatorInterceptor
{
    public IValidationContext BeforeAspNetValidation(ActionContext actionContext, IValidationContext commonContext)
    {
        return commonContext;
    }

    public ValidationResult AfterAspNetValidation(ActionContext actionContext, IValidationContext commonContext,
        ValidationResult validationResult)
    {
        if (validationResult.IsValid)
        {
            return validationResult;
        }

        var error = validationResult.Errors.First().ErrorMessage;

        throw ApiException.BadRequest(error);
    }
}