namespace Eshop.Application.Helpers.Validation
{
    public static class ErrorMessages
    {
        public static class User
        {
            // LastName
            public const string LastNameEmpty = "Lastname is required.";

            // FirstName
            public const string FirstNameEmpty = "Firstname is required.";

            // FirstName
            public const string EmailEmpty = "Email is required.";
            public const string EmailIsReal = "Email must be valid.";

            // Password
            public const string PasswordEmpty = "Password is required.";
            public const string PasswordLength = "Password must be at least 6 digits.";
            public const string PasswordUppercaseLetter = "Password must contain upper case letter.";
            public const string PasswordLowercaseLetter = "Password must contain lower case letter.";
            public const string PasswordDigit = "Password must contain digit.";
            public const string PasswordSpecialCharacter = "Password must contain special character.";

            // ConfirmPassword
            public const string ConfirmPasswordEmpty = "Confirm Password.";
            public const string ConfirmPasswordNotEqualPassword = "Confirm Password.";
        }
    }
}