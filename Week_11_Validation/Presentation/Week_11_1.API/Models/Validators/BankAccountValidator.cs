using FluentValidation;
using System.Security.Principal;
using Week_11_1.Domain.Entities;

namespace Week_11_1.API.Models.Validators
{
    public class BankAccountValidator :AbstractValidator<BankAccount>
    {
        public BankAccountValidator()
        {
            RuleFor(account => account.FirstName).NotEmpty().WithMessage("FirstName is required");
            RuleFor(account => account.LastName).NotEmpty().WithMessage("LastName is required");
            RuleFor(account => account.PhoneNumber).MaximumLength(10).WithMessage("PhoneNumber must be at most 10 characters");
            RuleFor(account => account.Balance)
              .NotEmpty().WithMessage("Balance is required.")
              .GreaterThan(0).WithMessage("Balance must be greater than zero.");
        }
    }
}
