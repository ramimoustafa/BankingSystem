 using BankingSystem.Domain.Models.Request;
using FluentValidation;

namespace BankingSystem.API.Validators
{
    public class TransferRequestValidator : AbstractValidator<TransferRequest>
    {
        public TransferRequestValidator()
        {

            RuleFor(x => x.SourceAccountNumber).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(x => x.DestinationAccountNumber).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(x => x.TransferTypeId).NotEmpty().NotNull();
            RuleFor(x => x.Amount).NotEmpty().NotNull().GreaterThan(0);

        }
    }
}
