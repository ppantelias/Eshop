using Eshop.Web.App.Extensions;

var builder = WebApplication.CreateBuilder(args);

await builder.Services.Configure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.ConfigureExceptionHandler();
app.Configure();
app.Run();