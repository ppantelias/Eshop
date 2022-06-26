using Microsoft.AspNetCore.Identity;

namespace Eshop.Database.Helpers
{
    public static class ApplicationUserManagerErrors
    {
        private static readonly string _userAlreadyExistsCode = "17000";
        private static readonly string _userAlreadyExistsDescription = "User already exists";

        public static IdentityError UserAlreadyExists
            => new()
            {
                Code = _userAlreadyExistsCode,
                Description = _userAlreadyExistsDescription
            };
    }
}