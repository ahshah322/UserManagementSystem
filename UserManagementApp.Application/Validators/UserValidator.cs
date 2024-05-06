using FluentValidation;
using UserManagementApp.Domain.Entities;

namespace UserManagementApp.Application.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.Name)
                .NotEmpty()
                .WithMessage("User name is required.")
                .MaximumLength(50);
            RuleFor(user => user.CNIC)
                .NotEmpty()
                .Matches("^[0-9]{13}$")
                .WithMessage("CNIC must be a 13 digit number.");
            RuleFor(user => user.PhoneNumber)
                .NotEmpty()
                .Matches("^[0-9]{11}$")
                .WithMessage("Phone number must be an 11 digit number.");
        }
    }
}
