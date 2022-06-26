using Eshop.Application.Users.CreateUser;
using Eshop.Domain.Models.Identity;

namespace Eshop.Application.Helpers
{
    public static class CreateUserExtensions
    {
        public static readonly string ErrorMessage = "Invalid request. Firstname, Lastname, Email, Password must be filled.";
        public static readonly string DefaultErrorCode = "DefaultError";

        public static bool IsNotValid(this CreateUserRequest @this)
            => @this.Firstname.IsNullOrEmpty() || @this.Lastname.IsNullOrEmpty() || @this.Email.IsNullOrEmpty() || @this.Password.IsNullOrEmpty();

        public static ApplicationUser ToApplicationUser(this CreateUserRequest @this)
            => new ApplicationUser()
            {
                Firstname = @this.Firstname,
                Lastname = @this.Lastname,
                Email = @this.Email
            };
    }
}