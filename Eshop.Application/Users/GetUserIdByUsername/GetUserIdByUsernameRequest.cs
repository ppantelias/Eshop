using MediatR;

namespace Eshop.Application.Users.GetUserIdByUsername
{
    public class GetUserIdByUsernameRequest : IRequest<GetUserIdByUsernameRequestResponse>
    {
        public string Username { get; set; }
    }
}