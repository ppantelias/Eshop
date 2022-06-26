using Eshop.Application.Helpers;
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

        public async Task<GetAllUsersRequestResponse> Handle(GetAllUsersRequest request, CancellationToken cancellationToken)
        {
            var response = _applicationUserManager.GetAllUsers();

            return new GetAllUsersRequestResponse
            {
                Users = response.MapToDto()
            };
        }
    }
}