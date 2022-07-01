using MediatR;

namespace Eshop.Application.Users.CreateUser
{
    public class CreateUserRequest : IRequest<CreateUserRequestResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}