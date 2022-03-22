namespace Controller.Controllers
{
    using System.Security.Claims;
    using Common.Authentication;
    using Controller.Base;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Repository.Contexts;
    using Repository.Entities;

    [Route("account")]
    [AllowAnonymous]
    public class AccountController : CustomControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public AccountController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [Route("login")]
        public async Task<IActionResult> Login()
        {
            (Guid userId, Guid tenantId) = await GetOrCreateDefaultUserAndTenant();
            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
            identity.AddClaim(new Claim(ApplicationClaims.UserId, userId.ToString()));
            identity.AddClaim(new Claim(ApplicationClaims.TenantId, tenantId.ToString()));
            var principal = new ClaimsPrincipal(identity);
            var authProperties = new AuthenticationProperties();

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(principal), authProperties);

            return Redirect("/");
        }

        // Todo - Temporary code to simplify user creation
        private async Task<(Guid UserId, Guid TenantId)> GetOrCreateDefaultUserAndTenant()
        {
            const string defaultTenantName = "Default Tenant";
            const string defaultUserName = "Default Name";

            Tenant? tenant = await _applicationDbContext.Tenants.SingleOrDefaultAsync(p => p.Name == defaultTenantName);

            if (tenant == null)
            {
                tenant = new Tenant(defaultTenantName);
                _applicationDbContext.Tenants.Add(tenant);
            }

            User? user = await _applicationDbContext.Users.Include(p => p.Tenants).SingleOrDefaultAsync(p => p.UserName == defaultUserName);

            if (user == null)
            {
                user = new User { UserName = defaultUserName };
                _applicationDbContext.Users.Add(user);
            }

            if (user.Tenants.All(p => p.Id != tenant.Id))
            {
                user.Tenants.Add(tenant);
            }

            await _applicationDbContext.SaveChangesAsync();

            return (user.Id, tenant.Id);
        }
    }
}