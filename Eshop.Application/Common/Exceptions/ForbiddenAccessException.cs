namespace Eshop.Application.Common.Exceptions
{
    public class ForbiddenAccessException : Exception
    {
        private const string _errorMessage = "Access denied";
        public ForbiddenAccessException(string message = _errorMessage) : base(message)
        {

        }
    }
}