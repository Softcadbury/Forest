namespace Repository.Entities;

using Microsoft.AspNetCore.Identity;

public class User : IdentityUser<Guid>
{
    public List<Tenant> Tenants { get; }

    public User()
    {
        Tenants = new List<Tenant>();
    }
}