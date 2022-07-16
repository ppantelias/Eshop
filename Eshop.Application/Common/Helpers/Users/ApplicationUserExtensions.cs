using Eshop.Application.Common.Models.Dtos;
using Eshop.Application.Users.CreateUser;
using Eshop.Domain.Models.Identity;

namespace Eshop.Application.Common.Helpers.Users
{
    public static class ApplicationUserExtensions
    {
        public static IEnumerable<ApplicationUserDto> MapToDto(this IEnumerable<ApplicationUser> users)
        {
            var usersDto = new List<ApplicationUserDto>();

            foreach (var user in users)
            {
                usersDto.Add(user.MapToDto());
            }

            return usersDto;
        }

        public static ApplicationUserDto MapToDto(this ApplicationUser user)
            => new()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };

        public static ApplicationUser ToApplicationUser(this CreateUserRequest @this)
            => new()
            {
                FirstName = @this.FirstName,
                LastName = @this.LastName,
                Email = @this.Email
            };
    }
}