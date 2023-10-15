namespace Web.Configurations;

using Common.AppSettings;
using Microsoft.AspNetCore.Builder;
using Web.Middlewares;

public static class FrontConfiguration
{
    public static void ConfigureFront(this IServiceCollection services)
    {
        services.AddSpaStaticFiles(config =>
        {
            config.RootPath = "dist";
        });
    }

    public static void ConfigureFront(this IApplicationBuilder app, IWebHostEnvironment env, IConfiguration configuration)
    {
        if (env.IsDevelopment())
        {
            DevelopmentSettings developmentSettings = configuration.GetSection(DevelopmentSettings.SectionName).Get<DevelopmentSettings>();
            if (developmentSettings.EnableTypeScriptServicesGeneration)
            {
                app.UseMiddleware<GenerateTypescriptServicesMiddleware>();
            }
        }

        app.UseSpaStaticFiles();
 
        app.UseSpa(spa =>
        {
            if (env.IsDevelopment())
            {
                spa.UseProxyToSpaDevelopmentServer("http://localhost:5173/");
            }
        });
    }
}
