using Eshop.Application.Common.Abstract;

namespace Eshop.Application.Users.GetUserIdByUsername
{
    public class GetUserIdByUsernameRequestResponse : AbstractResponse
    {
        public Guid? UserId { get; set; }
    }
}