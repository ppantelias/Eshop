using Eshop.Application.Abstract;
using Eshop.Application.Helpers.Users;
using Eshop.Database.Managers;
using MediatR;

namespace Eshop.Application.Users.GetAllUsers
{
    public class GetAllUsersRequestHandler : IRequestHandler<GetAllUsersRequest, GetAllUsersRequestResponse>
    {
        private readonly ApplicationUserManager _applicationUserManager;

        public GetAllUsersRequestHandler(ApplicationUserManager applicationUserManager)
        {
            _applicationUserManager = applicationUserManager;
        }

        public Task<GetAllUsersRequestResponse> Handle(GetAllUsersRequest request, CancellationToken cancellationToken)
        {
            var response = _applicationUserManager.GetAllUsers();

            return Task.FromResult(new GetAllUsersRequestResponse
            {
                Users = response.MapToDto(),
                Succeeded = true,
                ResponseCode = ResponseCode.Succeded
            });
        }
    }
}