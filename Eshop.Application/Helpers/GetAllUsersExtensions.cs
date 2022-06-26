using Eshop.Application.DtoModels;
using Eshop.Domain.Models.Identity;

namespace Eshop.Application.Helpers
{
    public static class GetAllUsersExtensions
    {
        public static IEnumerable<ApplicationUserDto> MapToDto(this IEnumerable<ApplicationUser> users){
            var usersDto = new List<ApplicationUserDto>();

            foreach (var user in users)
            {
                usersDto.Add(user.MapToDto());
            }

            return usersDto;
        }

        public static ApplicationUserDto MapToDto(this ApplicationUser user)
            => new ApplicationUserDto
            {
                Id = user.Id,
                FirstName = user.Firstname,
                LastName = user.Lastname,
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };
    }
}