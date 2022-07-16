namespace Eshop.Application.Helpers.Validation
{
    public static class ErrorMessages
    {
        private static readonly string _required = "{0} is required.";

        public static class User
        {
            //// LastName
            //public const string LastNameEmpty = "Lastname is required.";

            //// FirstName
            //public const string FirstNameEmpty = "Firstname is required.";

            //// Email
            //public const string EmailEmpty = "Email is required.";
            public const string EmailIsReal = "Email must be valid.";

            // Password
            //public const string PasswordEmpty = "Password is required.";
            public const string PasswordLength = "Password must be at least 6 digits.";
            public const string PasswordUppercaseLetter = "Password must contain upper case letter.";
            public const string PasswordLowercaseLetter = "Password must contain lower case letter.";
            public const string PasswordDigit = "Password must contain digit.";
            public const string PasswordSpecialCharacter = "Password must contain special character.";

            // ConfirmPassword
            //public const string ConfirmPasswordEmpty = "Confirm Password is required.";
            public const string ConfirmPasswordNotEqualPassword = "Confirm Password not equal with password.";

            //// Usename
            //public const string UsernameEmpty = "Username is required.";
        }

        public static string IsRequired(this string @this)
            => string.Format(_required, @this);
    }
}