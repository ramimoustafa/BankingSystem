using BankingSystem.Domain.Models.Request;
using FluentValidation;

namespace BankingSystem.API.Validators
{
    public class TransactionRequestValidator : AbstractValidator<TransactionRequest>
    {
        public TransactionRequestValidator()
        {
            RuleFor(x => x.From).NotEmpty().NotNull();
            RuleFor(x => x.To).GreaterThan(x => x.From);

            RuleFor(x => x.PageSize).NotEmpty().NotNull().GreaterThan(0);

            RuleFor(x => x.PageNumber).NotEmpty().NotNull().GreaterThan(0);


        }
    }
}
