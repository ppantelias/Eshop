using Eshop.Application.Common.Helpers.Tools;
using Eshop.Database.Helpers.AppStart;
using Microsoft.AspNetCore.Diagnostics;
using System.Text;

namespace Eshop.Web.App.Extensions
{
    public static class ConfigureApplicationBuilder
    {
        public static void Configure(this IApplicationBuilder @this)
            => @this
                .UseSwaggerUI()
                .UseHttpsRedirection()
                .UseStaticFiles()
                .UseRouting()
                .UseCors(options => options
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod())
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                })
                .ApplyMigrations();

        private static IApplicationBuilder UseSwaggerUI(this IApplicationBuilder @this)
            => @this
                .UseSwagger()
                .UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Eshop");
                    options.RoutePrefix = string.Empty;
                });

        private static void ApplyMigrations(this IApplicationBuilder @this)
            => ConfigureApplication.ApplyMigrations(@this);

        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var exception = errorFeature.Error;
                    context.Response.ContentType = "application/json";
                    var errorDetails = exception.MapException();
                    context.Response.StatusCode = errorDetails.StatusCode;

                    await context.Response.WriteAsync(errorDetails.Serialize(), Encoding.UTF8);
                });
            });
        }
    }
}