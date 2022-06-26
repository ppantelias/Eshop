using Eshop.Web.App.Filters;
using Microsoft.OpenApi.Models;
using System.Reflection;
using MediatR;
using Eshop.Database.Helpers.AppStart;

namespace Eshop.Web.App.Extensions
{
    public static class ServiceRegister
    {
        public static async Task Configure(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddControllersWithViews();
            services.AddServices(configuration);

            await services.SeedRolesAndFullAdminAsync(configuration);
        }

        public static void AddServices(this IServiceCollection services, ConfigurationManager configuration)
            => services
                .AddMediatR(Assembly.GetExecutingAssembly())
                .AddDatabaseServices(configuration)
                .AddSwagger()
                .AddApiControllers();

        public static async Task SeedRolesAndFullAdminAsync(this IServiceCollection services, ConfigurationManager configuration)
            => await ConfigureServices.SeedRolesAndFullAdminAsync(services, configuration);

        private static IServiceCollection AddSwagger(this IServiceCollection services)
            => services
                .AddSwaggerGen(c =>
                {
                    c.SwaggerDoc(
                        "v1",
                        new OpenApiInfo
                        {
                            Title = "Eshop",
                            Version = "v1"
                        });
                });

        private static void AddApiControllers(this IServiceCollection services)
            => services
                .AddControllers(options => options
                    .Filters
                    .Add<ModelOrNotFoundActionFilter>());
    }
}