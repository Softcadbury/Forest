namespace Web.Middlewares
{
    using Microsoft.AspNetCore.Http;
    using NSwag;
    using NSwag.CodeGeneration.TypeScript;

    public class GenerateTypescriptServicesMiddleware
    {
        private static bool _isGenerated;
        private readonly RequestDelegate _next;

        public GenerateTypescriptServicesMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (!_isGenerated)
            {
                var document = await OpenApiDocument.FromUrlAsync("https://localhost:5001/swagger/v1/swagger.json");
                var settings = new TypeScriptClientGeneratorSettings { ClassName = "{controller}Client" };
                var generator = new TypeScriptClientGenerator(document, settings);
                var code = generator.GenerateFile();
                await File.WriteAllTextAsync("../Client/src/services/generated-services.ts", code);
                _isGenerated = true;
            }

            await _next(context);
        }
    }
}