namespace Repository.Entities.Base
{
    public abstract class TenantEntityBase : EntityBase
    {
        protected TenantEntityBase(Guid tenantId)
        {
            TenantId = tenantId;
        }

        public Guid TenantId { get; set; }
    }
}