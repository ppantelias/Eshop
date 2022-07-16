﻿using Eshop.Application.Users.GetAllUsers;
using Eshop.Web.App.Controllers.Base;
using Eshop.Web.App.Models;
using Eshop.Web.App.RequestMappers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using CreateUser = Eshop.Application.Users.CreateUser;

namespace Eshop.Web.App.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator)); ;
        }

        [HttpPost]
        public async Task<GenericApiResponse<CreateUser.CreateUserRequestResponse>> Create(
            [FromBody] CreateUserRequest request,
            CancellationToken cancellationToken)
        {
            try
            {
                var response = await _mediator.Send(request.MapCreateUserRequest(), cancellationToken);

                return new GenericApiResponse<CreateUser.CreateUserRequestResponse>(response);
            }
            catch (Exception ex)
            {
                return new GenericApiResponse<CreateUser.CreateUserRequestResponse>
                {
                    Succeeded = false,
                    HttpStatusCode = HttpStatusCode.InternalServerError,
                    Errors = new string[] { ex.Message }
                };
            }

        }

        [HttpGet]
        public async Task<GenericApiResponse<GetAllUsersRequestResponse>> GetAll(CancellationToken cancellationToken)
        {
            try
            {
                var response =  await _mediator.Send(new GetAllUsersRequest(), cancellationToken);

                return new GenericApiResponse<GetAllUsersRequestResponse>(response);
            }
            catch (Exception ex)
            {
                return new GenericApiResponse<GetAllUsersRequestResponse>
                {
                    Succeeded = false,
                    HttpStatusCode = HttpStatusCode.InternalServerError,
                    Errors = new string[] { ex.Message }
                };
            }
        }
    }
}