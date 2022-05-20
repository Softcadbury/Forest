namespace Web.Configurations;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Resources;

public static class ResourcesConfiguration
{
    public static void ConfigureResources(this IServiceCollection services)
    {
        services.AddLocalization(options => options.ResourcesPath = "Resources");
    }

    public static void ConfigureResources(this IApplicationBuilder app)
    {
        app.UseRequestLocalization(new RequestLocalizationOptions
        {
            DefaultRequestCulture = new RequestCulture(SharedResource.DefaultCultureInfo),
            SupportedCultures = SharedResource.GetSupportedCulturesInfo(),
            SupportedUICultures = SharedResource.GetSupportedCulturesInfo(),
            RequestCultureProviders = new List<IRequestCultureProvider> { new AcceptLanguageHeaderRequestCultureProvider() },
        });
    }
}