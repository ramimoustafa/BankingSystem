using BankingSystem.Domain.Models.DTO;
using FluentValidation;

namespace BankingSystem.API.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().NotNull().Length(0, 20);
            RuleFor(x => x.LastName).NotEmpty().NotNull().Length(0, 20);
            RuleFor(x => x.MiddleName).NotEmpty().NotNull().Length(0, 20);
            RuleFor(x => x.DOB).NotEmpty().NotNull();
            RuleFor(x => x.GenderId).NotEmpty().NotNull();
            RuleFor(x => x.UserTypeId).NotEmpty().NotNull();
            RuleFor(x => x.BranchId).NotEmpty().NotNull();
 
        }
    }
}
