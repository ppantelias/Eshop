namespace Eshop.Web.App.Models
{
    public class CreateUserRequest
    {
        public string? Firstname { get; set; }

        public string? Lastname { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}