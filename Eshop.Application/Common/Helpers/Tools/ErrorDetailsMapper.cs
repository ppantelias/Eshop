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
                    Message = @this.Message
                },
                UnauthorizedAccessException => new ErrorDetails()
                {
                    StatusCode = (int)HttpStatusCode.Unauthorized,
                    Message = @this.Message
                },
                ForbiddenAccessException => new ErrorDetails()
                {
                    StatusCode = (int)HttpStatusCode.Forbidden,
                    Message = @this.Message
                },
                ValidationException => new ErrorDetails()
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = ((ValidationException)@this).Errors?.Serialize()
                },
                _ => new ErrorDetails()
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Message = @this.Message
                }
            };
    }
}