namespace Repository.Entities
{
    using Repository.Entities.Base;

    public class User : EntityBase
    {
        public List<Tenant> Tenants { get; }

        public User()
        {
            Tenants = new List<Tenant>();
        }
    }
}