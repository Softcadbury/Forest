namespace Web.Configurations
{
    using Controller.Api;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Builder;
    using Repository.Contexts;
    using Repository.Entities;

    public static class AuthenticationConfiguration
    {
        public static void ConfigureAuthentication(this IServiceCollection services)
        {
            services.AddIdentityCore<User>().AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                options.SlidingExpiration = true;
                options.Events.OnRedirectToAccessDenied =
                options.Events.OnRedirectToLogin = c =>
                {
                    c.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    return Task.FromResult<object?>(null);
                };
            });

            services.AddControllersWithViews().AddApplicationPart(typeof(TreeController).Assembly);
        }

        public static void ConfigureAuthentication(this IApplicationBuilder app)
        {
            app.UseCookiePolicy(new CookiePolicyOptions { MinimumSameSitePolicy = SameSiteMode.Strict, });
        }
    }
}