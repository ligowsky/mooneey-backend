using FluentValidation;
using Mooneey.Domain;

namespace Mooneey.Presentation.Validation;

public class AccountCreateRequestValidator : AbstractValidator<AccountCreateRequestViewModel>
{
    public AccountCreateRequestValidator()
    {
        RuleFor(x => x.AccountType).NotEmpty().IsInEnum();
        RuleFor(x => x.CurrencyCode).NotEmpty().IsInEnum();
        RuleFor(x => x.Name).NotEmpty().Length(1, 64);
        RuleFor(x => x.Balance).NotEmpty();
    }
}