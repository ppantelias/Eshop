namespace Eshop.Application.Common.Helpers.Validation
{
    public static class ErrorMessages
    {
        private static readonly string _required = "{0} is required.";

        public static class User
        {
            // Email
            public const string EmailIsReal = "Email must be valid.";

            // Password
            public const string PasswordLength = "Password must be at least 6 digits.";

            public const string PasswordUppercaseLetter = "Password must contain upper case letter.";
            public const string PasswordLowercaseLetter = "Password must contain lower case letter.";
            public const string PasswordDigit = "Password must contain digit.";
            public const string PasswordSpecialCharacter = "Password must contain special character.";

            // ConfirmPassword
            public const string ConfirmPasswordNotEqualPassword = "Confirm Password not equal with password.";
        }

        public static string IsRequired(this string @this)
            => string.Format(_required, @this);
    }
}