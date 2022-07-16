using Eshop.Application.Abstract;
using Eshop.Application.Helpers.Users;
using Eshop.Database.Managers;
using MediatR;

namespace Eshop.Application.Users.CreateUser
{
    public class CreateUserRequestHandler : IRequestHandler<CreateUserRequest, CreateUserRequestResponse>
    {
        private readonly ApplicationUserManager _applicationUserManager;
        public CreateUserRequestHandler(ApplicationUserManager applicationUserManager)
        {
            _applicationUserManager = applicationUserManager;
        }

        public async Task<CreateUserRequestResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var user = request.ToApplicationUser();

            var response = await _applicationUserManager.CreateAsync(user);

            if (response.Succeeded)
            {
                response = await _applicationUserManager.AddPasswordAsync(user, request.Password);
            }

            return new CreateUserRequestResponse()
            {
                Succeeded = response.Succeeded,
                Errors = response.Errors?.Select(e => e.Description)?.ToArray(),
                ResponseCode = response.Succeeded ? ResponseCode.Succeded : ResponseCode.Failed
            };
        }
    }
}