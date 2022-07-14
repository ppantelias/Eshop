using Eshop.Application.Users.CreateUser;
using ContollerRequestModels = Eshop.Web.App.Models;

namespace Eshop.Web.App.RequestMappers
{
    public static class UserRequestMapper
    {
        public static CreateUserRequest MapCreateUserRequest(this ContollerRequestModels.CreateUserRequest @this)
            => new()
            {
                FirstName = @this.FirstName,
                LastName = @this.LastName,
                Email = @this.Email,
                Password = @this.Password,
                ConfirmPassword = @this.ConfirmPassword
            };
    }
}