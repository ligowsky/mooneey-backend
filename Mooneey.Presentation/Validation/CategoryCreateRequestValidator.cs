using FluentValidation;
using Mooneey.Presentation.ViewModels.Request;

namespace Mooneey.Presentation.Validation;

public class CategoryCreateRequestValidator : AbstractValidator<CategoryCreateRequest>
{
    public CategoryCreateRequestValidator()
    {
        RuleFor(c => c.Name).NotEmpty().MaximumLength(64);
    }
}