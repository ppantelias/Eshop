using Eshop.Application.Common.Models.Enums;
using Eshop.Database.Managers;
using MediatR;

namespace Eshop.Application.Users.GetUserIdByUsername
{
    public class GetUserIdByUsernameRequestHandler : IRequestHandler<GetUserIdByUsernameRequest, GetUserIdByUsernameRequestResponse>
    {
        private readonly ApplicationUserManager _applicationUserManager;

        public GetUserIdByUsernameRequestHandler(ApplicationUserManager applicationUserManager)
        {
            _applicationUserManager = applicationUserManager;
        }

        public async Task<GetUserIdByUsernameRequestResponse> Handle(GetUserIdByUsernameRequest request, CancellationToken cancellationToken)
        {
            var user = await _applicationUserManager.FindUserByNameAsync(request.Username);

            if (user == default || user == null)
                return new GetUserIdByUsernameRequestResponse()
                {
                    Succeeded = false,
                    ResponseCode = ResponseCode.NotFound
                };

            return new GetUserIdByUsernameRequestResponse()
            {
                UserId = user.Id
            };
        }
    }
}