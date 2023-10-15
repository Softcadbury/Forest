using Microsoft.EntityFrameworkCore;
using Repository.Contexts;
using Web.Configurations;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
{
    builder.Services.ConfigureSettings(builder.Configuration);
    builder.Services.ConfigureAuthentication();
    builder.Services.ConfigureSwagger();
    builder.Services.ConfigureFront();
    builder.Services.ConfigureResources();
    builder.Services.ConfigureDependencies(builder.Configuration);
}

WebApplication app = builder.Build();
{
    app.ConfigureResources();
    app.ConfigureRouting(app.Environment);
    app.ConfigureAuthentication();
    app.ConfigureMiddlewares();
    app.ConfigureSwagger(app.Environment);
    app.ConfigureFront(app.Environment, builder.Configuration);

    // Migrate database
    using IServiceScope scope = app.Services.CreateScope();
    IServiceProvider services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate();
}

app.Run();