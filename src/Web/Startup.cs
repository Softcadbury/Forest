namespace Web
{
    using System.Reflection;
    using Common.AppSettings;
    using Controller.Api;
    using Controller.Mapping;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.OpenApi.Models;
    using Repository.Contexts;
    using Swashbuckle.AspNetCore.SwaggerGen;
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

            services.AddControllersWithViews().AddApplicationPart(typeof(TreeController).Assembly);

            services.AddSwaggerGen(configuration =>
            {
                configuration.SwaggerDoc("v1", new OpenApiInfo { Title = "Forest", Version = "v1" });
                configuration.CustomOperationIds(p =>
                {
                    p.TryGetMethodInfo(out MethodInfo methodInfo);
                    string controllerName = methodInfo.DeclaringType!.Name.Replace("Controller", string.Empty, StringComparison.InvariantCultureIgnoreCase);
                    string methodName = methodInfo.Name;
                    return controllerName + methodName;
                });
                configuration.CustomSchemaIds(p => p.Name.Replace("ViewModel", string.Empty, StringComparison.InvariantCultureIgnoreCase));
            });

            services.AddSpaStaticFiles(config =>
            {
                config.RootPath = "dist";
            });

            services.AddDbContext<Context>(p => p.UseSqlServer(Configuration.GetConnectionString("Main")));

            services.AddAutoMapper(typeof(MapperConfiguration));

            services.ConfigureResources();
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

            if (env.IsDevelopment())
            {
                DevelopmentSettings developmentSettings = Configuration.GetSection(DevelopmentSettings.SectionName).Get<DevelopmentSettings>();
                if (developmentSettings.EnableTypeScriptServicesGeneration)
                {
                    app.UseMiddleware<GenerateTypescriptServicesMiddleware>();
                }
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });

            app.UseSpa(spa =>
            {
                if (env.IsDevelopment())
                {
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:3000/");
                }
            });

            app.ConfigureResources();
        }
    }
}