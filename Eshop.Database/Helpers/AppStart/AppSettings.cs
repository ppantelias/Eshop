namespace Eshop.Database.Helpers.AppStart
{
    public static class AppSettings
    {
        public class ConnectionStrings
        {
            public static readonly string DefaultDbConnection;
        }

        public class SeedFullAdmin
        {
            public static readonly string UserName;
            public static readonly string Lastname;
            public static readonly string Firstname;
            public static readonly string Email;
            public static readonly string Password;
        }
    }
}