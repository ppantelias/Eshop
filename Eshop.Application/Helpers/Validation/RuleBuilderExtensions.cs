using FluentValidation;

namespace Eshop.Application.Helpers.Validation
{
    public static class RuleBuilderExtensions
    {
        public static IRuleBuilder<T, string> FirstName<T>(this IRuleBuilder<T, string> ruleBuilder)
            => ruleBuilder
                .NotEmpty().WithMessage(ErrorMessages.User.FirstNameEmpty);

        public static IRuleBuilder<T, string> LastName<T>(this IRuleBuilder<T, string> ruleBuilder)
            => ruleBuilder
                .NotEmpty().WithMessage(ErrorMessages.User.LastNameEmpty);

        public static IRuleBuilder<T, string> Email<T>(this IRuleBuilder<T, string> ruleBuilder)
            => ruleBuilder
                .NotEmpty().WithMessage(ErrorMessages.User.EmailEmpty)
                .EmailAddress().WithMessage(ErrorMessages.User.EmailIsReal);

        public static IRuleBuilder<T, string> Password<T>(this IRuleBuilder<T, string> ruleBuilder)
            => ruleBuilder
                .NotEmpty().WithMessage(ErrorMessages.User.PasswordEmpty)
                .MinimumLength(6).WithMessage(ErrorMessages.User.PasswordLength)
                .Matches("[A-Z]").WithMessage(ErrorMessages.User.PasswordUppercaseLetter)
                .Matches("[a-z]").WithMessage(ErrorMessages.User.PasswordLowercaseLetter)
                .Matches("[0-9]").WithMessage(ErrorMessages.User.PasswordDigit)
                .Matches("[^a-zA-Z0-9]").WithMessage(ErrorMessages.User.PasswordSpecialCharacter);

        public static IRuleBuilder<T, string> ConfirmPassword<T>(this IRuleBuilder<T, string> ruleBuilder, Func<T, string> password)
            => ruleBuilder
                .NotEmpty().WithMessage(ErrorMessages.User.ConfirmPasswordEmpty)
                .Must((instance, passwordValue) => password(instance).Equals(passwordValue)).WithMessage(ErrorMessages.User.ConfirmPasswordNotEqualPassword);
    }
}