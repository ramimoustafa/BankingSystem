using BankingSystem.Domain.Models.DTO;
using FluentValidation;

namespace BankingSystem.API.Validators
{
    public class AccountValidator : AbstractValidator<Account>
    {
        public AccountValidator()
        { 
            RuleFor(x => x.Number).GreaterThan(0);
            RuleFor(x => x.CurrencyId).NotEmpty().NotNull();
            RuleFor(x => x.AccountTypeId).NotEmpty().NotNull();
            RuleFor(x => x.UserId).NotEmpty().NotNull();
            RuleFor(x => x.Created).NotEmpty().NotNull();

        }
    }
}
