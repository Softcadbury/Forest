namespace Web.Configurations
{
    using Microsoft.AspNetCore.Builder;
    using Web.Middlewares;

    public static class MiddlewaresConfiguration
    {
        public static void ConfigureMiddlewares(this IApplicationBuilder app)
        {
            app.UseMiddleware<CurrentContextInitializerMiddleware>();
        }
    }
}