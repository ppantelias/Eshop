using Eshop.Application.Users.CreateUser;
using ContollerRequestModels = Eshop.Web.App.Models;

namespace Eshop.Web.App.RequestMappers
{
    public static class UserRequestMapper
    {
        public static CreateUserRequest MapCreateUserRequest(this ContollerRequestModels.CreateUserRequest @this)
            => new()
            {
                Firstname = @this.Firstname,
                Lastname = @this.Lastname,
                Email = @this.Email,
                Password = @this.Password
            };
    }
}