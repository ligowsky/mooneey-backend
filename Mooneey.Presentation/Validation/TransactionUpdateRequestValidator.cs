using FluentValidation;
using Mooneey.Presentation.ViewModels.Request;

namespace Mooneey.Presentation.Validation;

public class TransactionUpdateRequestValidator: AbstractValidator<TransactionUpdateRequest>
{
    public TransactionUpdateRequestValidator()
    {
        RuleFor(t => t.TransactionType).NotEmpty().IsInEnum();
        RuleFor(t => t.AccountId).NotEmpty();
        RuleFor(t => t.CategoryId).NotNull();
        RuleFor(t => t.Amount).NotNull().GreaterThan(0);
    }
}