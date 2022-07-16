using FluentValidation;

namespace Eshop.Application.Common.Helpers.Validation
{
    public static class RuleBuilderExtensions
    {
        public static IRuleBuilder<T, string> FirstName<T>(this IRuleBuilder<T, string> ruleBuilder)
            => ruleBuilder
                .NotEmpty().WithMessage(nameof(FirstName).IsRequired());

        public static IRuleBuilder<T, string> LastName<T>(this IRuleBuilder<T, string> ruleBuilder)
            => ruleBuilder
                .NotEmpty().WithMessage(nameof(LastName).IsRequired());

        public static IRuleBuilder<T, string> Email<T>(this IRuleBuilder<T, string> ruleBuilder)
            => ruleBuilder
                .NotEmpty().WithMessage(nameof(Email).IsRequired())
                .EmailAddress().WithMessage(ErrorMessages.User.EmailIsReal);

        public static IRuleBuilder<T, string> Password<T>(this IRuleBuilder<T, string> ruleBuilder)
            => ruleBuilder
                .NotEmpty().WithMessage(nameof(Password).IsRequired())
                .MinimumLength(6).WithMessage(ErrorMessages.User.PasswordLength)
                .Matches("[A-Z]").WithMessage(ErrorMessages.User.PasswordUppercaseLetter)
                .Matches("[a-z]").WithMessage(ErrorMessages.User.PasswordLowercaseLetter)
                .Matches("[0-9]").WithMessage(ErrorMessages.User.PasswordDigit)
                .Matches("[^a-zA-Z0-9]").WithMessage(ErrorMessages.User.PasswordSpecialCharacter);

        public static IRuleBuilder<T, string> ConfirmPassword<T>(this IRuleBuilder<T, string> ruleBuilder, Func<T, string> password)
            => ruleBuilder
                .NotEmpty().WithMessage(nameof(ConfirmPassword).IsRequired())
                .Must((instance, passwordValue) => password(instance).Equals(passwordValue)).WithMessage(ErrorMessages.User.ConfirmPasswordNotEqualPassword);

        public static IRuleBuilder<T, string> Username<T>(this IRuleBuilder<T, string> ruleBuilder)
            => ruleBuilder
                .NotEmpty().WithMessage(nameof(Username).IsRequired());
    }
}