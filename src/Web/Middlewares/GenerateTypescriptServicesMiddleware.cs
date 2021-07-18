﻿namespace Web.Middlewares
{
    using System.IO;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Hosting;
    using NSwag;
    using NSwag.CodeGeneration.TypeScript;

    public class GenerateTypescriptServicesMiddleware
    {
        private readonly RequestDelegate _next;
        private static bool _isGenerated;

        public GenerateTypescriptServicesMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IWebHostEnvironment env)
        {
            if (!_isGenerated && env.IsDevelopment())
            {
                var document = await OpenApiDocument.FromUrlAsync("https://localhost:5001/swagger/v1/swagger.json");
                var settings = new TypeScriptClientGeneratorSettings { ClassName = "{controller}Client" };
                var generator = new TypeScriptClientGenerator(document, settings);
                var code = generator.GenerateFile();
                await File.WriteAllTextAsync("ClientApp/src/services/generated-services.ts", code);
                _isGenerated = true;
            }

            await _next(context);
        }
    }
}