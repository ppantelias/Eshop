using Eshop.Application.Common.Abstract;
using Eshop.Application.Common.Models.Dtos;

namespace Eshop.Application.Users.GetAllUsers
{
    public class GetAllUsersRequestResponse : AbstractResponse
    {
        public IEnumerable<ApplicationUserDto> Users { get; set; }
    }
}