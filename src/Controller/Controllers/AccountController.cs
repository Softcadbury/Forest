namespace Controller.Controllers
{
    using System.Security.Claims;
    using Common.Authentication;
    using Controller.Base;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Route("account")]
    [AllowAnonymous]
    public class AccountController : CustomControllerBase
    {
        [Route("login")]
        public async Task<IActionResult> Login()
        {
            // Todo - Handle user creation properly

            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
            identity.AddClaim(new Claim(ApplicationClaims.TenantId, "db70957e-4faa-4169-80be-f5d543c98cc2"));
            identity.AddClaim(new Claim(ApplicationClaims.TenantId, "1"));
            var principal = new ClaimsPrincipal(identity);
            var authProperties = new AuthenticationProperties();

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(principal), authProperties);

            return Redirect("/");
        }
    }
}