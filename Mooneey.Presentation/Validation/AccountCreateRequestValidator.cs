using FluentValidation;
using Mooneey.Presentation.ViewModels.Request;

namespace Mooneey.Presentation.Validation;

public class AccountCreateRequestValidator: AbstractValidator<AccountCreateRequest>
{
    public AccountCreateRequestValidator()
    {
        RuleFor(a => a.AccountType).NotEmpty().IsInEnum();
        RuleFor(a => a.Currency).NotEmpty().IsInEnum();
        RuleFor(a => a.Name).NotEmpty().MaximumLength(64);
        RuleFor(a => a.Balance).NotNull();
    }
}