using MediatR;

namespace Eshop.Application.Users.CreateUser
{
    public class CreateUserRequest : IRequest<CreateUserRequestResponse>
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}