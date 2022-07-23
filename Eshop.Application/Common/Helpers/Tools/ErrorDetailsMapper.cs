using Eshop.Application.Common.Abstract;
using Eshop.Application.Common.Exceptions;
using System.Net;

namespace Eshop.Application.Common.Helpers.Tools
{
    public static class ErrorDetailsMapper
    {
        public static ErrorDetails MapException(this Exception @this)
            => @this switch
            {
                NotFoundException => new ErrorDetails()
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Error = new Error
                    {
                        Message = @this.Message
                    }
                },
                UnauthorizedAccessException => new ErrorDetails()
                {
                    StatusCode = (int)HttpStatusCode.Unauthorized,
                    Error = new Error
                    {
                        Message = @this.Message
                    }
                },
                ForbiddenAccessException => new ErrorDetails()
                {
                    StatusCode = (int)HttpStatusCode.Forbidden,
                    Error = new Error
                    {
                        Message = @this.Message
                    }
                },
                ValidationException => new ErrorDetails()
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Error = new Error
                    {
                        Message = @this.Message,
                        Errors = ((ValidationException)@this).Errors
                    }
                },
                _ => new ErrorDetails()
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Error = new Error
                    {
                        Message = @this.Message
                    }
                }
            };
    }
}