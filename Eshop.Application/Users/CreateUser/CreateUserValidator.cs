using Eshop.Application.Helpers.Validation;
using FluentValidation;

namespace Eshop.Application.Users.CreateUser
{
    public class CreateUserValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.FirstName).FirstName();

            RuleFor(x => x.LastName).LastName();

            RuleFor(x => x.Email).Email();

            RuleFor(x => x.Password).Password();

            RuleFor(x => x.ConfirmPassword).ConfirmPassword(x => x.Password);
        }
    }
}