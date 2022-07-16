using Eshop.Application.Helpers.Validation;
using FluentValidation;

namespace Eshop.Application.Users.GetUserIdByUsername
{
    public class GetUserIdByUsernameValidator : AbstractValidator<GetUserIdByUsernameRequest>
    {
        public GetUserIdByUsernameValidator()
        {
            RuleFor(x => x.Username).Username();
        }
    }
}