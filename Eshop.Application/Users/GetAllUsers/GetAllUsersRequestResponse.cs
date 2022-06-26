using Eshop.Application.DtoModels;

namespace Eshop.Application.Users.GetAllUsers
{
    public class GetAllUsersRequestResponse
    {
        public IEnumerable<ApplicationUserDto> Users { get; set; }
    }
}