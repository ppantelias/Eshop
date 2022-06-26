using Eshop.Database.ApplicationDb;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Eshop.Database.Helpers.AppStart
{
    public static class ConfigureApplication
    {
        public static void ApplyMigrations(this IApplicationBuilder @this)
        {
            using var services = @this.ApplicationServices.CreateScope();

            var dbContext = services.ServiceProvider.GetService<ApplicationDbContext>();

            if (dbContext != null)
                dbContext.Database.Migrate();
        }
    }
}