using Eshop.Database.ApplicationDb;
using Eshop.Database.Helpers.AppContext;
using Eshop.Database.Interceptors;
using Eshop.Database.Managers;
using Eshop.Database.Services;
using Eshop.Database.Services.Interfaces;
using Eshop.Domain.Infrastructure;
using Eshop.Domain.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Eshop.Database.Helpers.AppStart
{
    public static class ConfigureServices
    {
        public static async Task SeedRolesAndFullAdminAsync(this IServiceCollection services, ConfigurationManager configuration)
        {
            using ServiceProvider serviceProvider = services.BuildServiceProvider();
            var userManager = serviceProvider.GetRequiredService<ApplicationUserManager>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
            await ContextSeed.SeedRolesAsync(roleManager);
            await ContextSeed.SeedFullAdminAsync(userManager, roleManager, configuration);
        }

        public static IServiceCollection AddDatabaseServices(this IServiceCollection services, ConfigurationManager configuration)
            => services
                .AddInterceptors()
                .AddDbContext(configuration)
                .AddIdentity()
                .AddServices()
                .AddManagers();

        private static IServiceCollection AddInterceptors(this IServiceCollection services)
            => services
                .AddScoped<BaseEntitySaveChangesInterceptor>();

        private static IServiceCollection AddDbContext(this IServiceCollection services, ConfigurationManager configuration)
            => services
                .AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString(nameof(AppSettings.ConnectionStrings.DefaultDbConnection))));

        private static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services
                .AddIdentityCore<ApplicationUser>(options =>
                {
                    options.User.RequireUniqueEmail = true;
                    options.Lockout.MaxFailedAccessAttempts = 3;
                })
                .AddRoles<ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddUserManager<ApplicationUserManager>();

            return services;
        }

        private static IServiceCollection AddManagers(this IServiceCollection services)
            => services
               .AddScoped(typeof(IBaseManager<>), typeof(BaseManager<>));

        private static IServiceCollection AddServices(this IServiceCollection services)
            => services
                .AddTransient<IDateTimeService, DateTimeService>();
    }
}