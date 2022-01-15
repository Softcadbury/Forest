namespace Controller.Base
{
    using Common.Authentication;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Authorize]
    public abstract class CustomApiControllerBase : ControllerBase
    {
        protected Guid GetCurrentTenantId()
        {
            return Guid.Parse(User.Claims.First(x => x.Type == ApplicationClaims.TenantId).Value);
        }

        protected Guid GetCurrentUserId()
        {
            return Guid.Parse(User.Claims.First(x => x.Type == ApplicationClaims.UserId).Value);
        }
    }
}