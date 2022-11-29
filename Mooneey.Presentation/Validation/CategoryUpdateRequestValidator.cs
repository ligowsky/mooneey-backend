using FluentValidation;
using Mooneey.Presentation.ViewModels.Request;

namespace Mooneey.Presentation.Validation;

public class CategoryUpdateRequestValidator : AbstractValidator<CategoryUpdateRequest>
{
    public CategoryUpdateRequestValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty().MaximumLength(64);
    }
}