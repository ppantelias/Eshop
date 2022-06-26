using Eshop.Database.Helpers.AppStart;

namespace Eshop.Web.App.Extensions
{
    public static class ApplicationBuilder
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
    }
}