namespace Web.Configurations;

using Common.AppSettings;

public static class AppSettingsConfiguration
{
    public static void ConfigureSettings(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<DevelopmentSettings>(configuration.GetSection(DevelopmentSettings.SectionName));
    }
}