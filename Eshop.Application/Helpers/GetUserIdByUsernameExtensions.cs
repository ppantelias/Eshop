using Eshop.Application.Users.GetUserIdByUsername;

namespace Eshop.Application.Helpers
{
    public static class GetUserIdByUsernameExtensions
    {
        public static bool IsNotValid(this GetUserIdByUsernameRequest @this)
            => string.IsNullOrEmpty(@this.Username);
    }
}