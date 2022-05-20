namespace Controller.Api;

using Controller.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/identity")]
public class IdentityController : CustomApiControllerBase
{
    [HttpGet("")]
    [AllowAnonymous]
    public ActionResult<bool> Get()
    {
        return Ok(User.Identity?.IsAuthenticated ?? false);
    }
}