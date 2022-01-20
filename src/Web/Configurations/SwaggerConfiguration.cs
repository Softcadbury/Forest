namespace Web.Configurations
{
    using System.Reflection;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.OpenApi.Models;
    using Swashbuckle.AspNetCore.SwaggerGen;

    public static class SwaggerConfiguration
    {
        public static void ConfigureSwagger(this IServiceCollection services)
        {
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
        }

        public static void ConfigureSwagger(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Forest v1");
                c.DefaultModelsExpandDepth(-1); // Remove schemas section
            });
        }
    }
}