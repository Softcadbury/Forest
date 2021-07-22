namespace Web
{
    using System.Reflection;
    using Controller.Api;
    using Controller.Mapping;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;
    using Repository.Contexts;
    using Swashbuckle.AspNetCore.SwaggerGen;
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
            services.AddControllersWithViews().AddApplicationPart(typeof(TreeController).Assembly);

            services.AddSwaggerGen(configuration =>
            {
                configuration.SwaggerDoc("v1", new OpenApiInfo { Title = "Forest", Version = "v1" });
                configuration.CustomOperationIds(p =>
                {
                    p.TryGetMethodInfo(out MethodInfo methodInfo);
                    string controllerName = methodInfo.DeclaringType!.Name.Replace("Controller", string.Empty);
                    string methodName = methodInfo.Name;
                    return controllerName + methodName;
                });
            });

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

            services.AddDbContext<Context>(p => p.UseSqlServer(Configuration.GetConnectionString("Main")));

            services.AddAutoMapper(typeof(MapperConfiguration));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Forest v1"));
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            if (env.IsDevelopment())
            {
                app.UseMiddleware<GenerateTypescriptServicesMiddleware>();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.Options.PackageManagerCommand = "yarn";
                    spa.UseReactDevelopmentServer("start");
                }
            });
        }
    }
}