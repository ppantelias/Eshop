using Microsoft.AspNetCore.Identity;

namespace Eshop.Application.Users.CreateUser
{
    public class CreateUserRequestResponse
    {
        public IdentityResult Result { get; set; }
    }
}