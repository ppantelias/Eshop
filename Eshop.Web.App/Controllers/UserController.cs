using Eshop.Application.Users.GetAllUsers;
using Eshop.Web.App.Controllers.Base;
using Eshop.Web.App.RequestMappers;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ContollerRequestModels = Eshop.Web.App.Models;

namespace Eshop.Web.App.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator)); ;
        }

        [HttpPost]
        public async Task<IdentityResult> CreateUserAsync(
            [FromBody] ContollerRequestModels.CreateUserRequest request,
            CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request.MapCreateUserRequest(), cancellationToken);

            return response.Result;
        }

        [HttpGet]
        public async Task<GetAllUsersRequestResponse> GetAllUsers(CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetAllUsersRequest(), cancellationToken);
        }
    }
}