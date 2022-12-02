using FluentValidation;
using Mooneey.Domain;

namespace Mooneey.Presentation.Validation;

public class AccountUpdateRequestValidator : AbstractValidator<AccountUpdateRequestViewModel>
{
    public AccountUpdateRequestValidator()
    {
        RuleFor(x => x.AccountType).NotNull().IsInEnum();
        RuleFor(x => x.CurrencyCode).NotNull().IsInEnum();
        RuleFor(x => x.Name).NotNull().Length(1, 64);
        RuleFor(x => x.Balance).NotNull();
    }
}