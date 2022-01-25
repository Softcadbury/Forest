namespace Web.Configurations
{
    using Common.Misc;
    using Controller.Mapping;
    using Microsoft.EntityFrameworkCore;
    using Repository.Contexts;

    public static class DependenciesConfiguration
    {
        public static void ConfigureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(p => p.UseSqlServer(configuration.GetConnectionString("Main")));

            services.AddAutoMapper(typeof(ApplicationMapperConfiguration));

            services.AddScoped(_ => new CurrentContext());
        }
    }
}