using Eshop.Application.Abstract;
using Eshop.Application.DtoModels;

namespace Eshop.Application.Users.GetAllUsers
{
    public class GetAllUsersRequestResponse: AbstractResponse
    {
        public IEnumerable<ApplicationUserDto> Users { get; set; }
    }
}