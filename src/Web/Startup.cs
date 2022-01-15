namespace Web
{
    using Common.Misc;
    using Controller.Mapping;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Repository.Contexts;
    using Web.Configurations;
    using Web.Middlewares;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureSettings(Configuration);
            services.ConfigureAuthentication();
            services.ConfigureSwagger();
            services.ConfigureFront();
            services.AddDbContext<ApplicationDbContext>(p => p.UseSqlServer(Configuration.GetConnectionString("Main")));
            services.AddAutoMapper(typeof(MapperConfiguration));
            services.ConfigureResources();

            services.AddScoped(_ => new CurrentContext());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Forest v1");
                    c.DefaultModelsExpandDepth(-1); // Remove schemas section
                });
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.ConfigureAuthentication();
            app.UseEndpoints(endpoints => { endpoints.MapDefaultControllerRoute(); });
            app.UseMiddleware<CurrentContextInitializerMiddleware>();
            app.ConfigureSwagger(env);
            app.ConfigureResources();
            app.ConfigureFront(env, Configuration);
        }
    }
}