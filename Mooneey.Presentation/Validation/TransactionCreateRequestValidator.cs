using FluentValidation;
using Mooneey.Presentation.ViewModels.Request;

namespace Mooneey.Presentation.Validation;

public class TransactionCreateRequestValidator: AbstractValidator<TransactionCreateRequest>
{
    public TransactionCreateRequestValidator()
    {
        RuleFor(t => t.TransactionType).NotEmpty().IsInEnum();
        RuleFor(t => t.AccountId).NotEmpty();
        RuleFor(t => t.CategoryId).NotNull();
        RuleFor(t => t.Amount).NotEmpty().NotNull().GreaterThan(0);
    }
}