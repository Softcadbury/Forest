namespace Web.Middlewares
{
    using Common.Misc;
    using Microsoft.AspNetCore.Http;
    using Namotion.Reflection;

    public class CurrentContextInitializerMiddleware
    {
        private readonly RequestDelegate _next;

        public CurrentContextInitializerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, CurrentContext currentContext)
        {
            currentContext.TenantId = context.User.Claims.TryGetPropertyValue<Guid>("TenantId");

            await _next(context);
        }
    }
}