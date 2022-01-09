namespace Web.Middlewares
{
    using Common.Misc;
    using Microsoft.AspNetCore.Http;

    public class CurrentContextInitializerMiddleware
    {
        private readonly RequestDelegate _next;

        public CurrentContextInitializerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, CurrentContext currentContext)
        {
            // todo - Initialize tenant id based on connected user
            currentContext.TenantId = Guid.Parse("db70957e-4faa-4169-80be-f5d543c98cc2");

            await _next(context);
        }
    }
}