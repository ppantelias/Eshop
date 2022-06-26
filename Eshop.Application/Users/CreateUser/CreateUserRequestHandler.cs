using Eshop.Application.Helpers;
using Eshop.Database.Managers;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Eshop.Application.Users.CreateUser
{
    [RequestHandler]
    public class CreateUserRequestHandler : IRequestHandler<CreateUserRequest, CreateUserRequestResponse>
    {
        private readonly ApplicationUserManager _applicationUserManager;
        public CreateUserRequestHandler(ApplicationUserManager applicationUserManager)
        {
            _applicationUserManager = applicationUserManager;
        }

        public async Task<CreateUserRequestResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            if (request.IsNotValid())
            {
                return new CreateUserRequestResponse()
                {
                    Result = IdentityResult.Failed(new IdentityError()
                    {
                        Code = CreateUserExtensions.DefaultErrorCode,
                        Description = CreateUserExtensions.ErrorMessage
                    })
                };
            }

            var user = request.ToApplicationUser();

            var response = await _applicationUserManager.CreateAsync(user);

            if (response.Succeeded)
            {
                response = await _applicationUserManager.AddPasswordAsync(user, request.Password);
            }

            return new CreateUserRequestResponse()
            {
                Result = response
            };
        }
    }
}