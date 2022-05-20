namespace Repository.Entities.Base;

public abstract class TenantEntityBase : EntityBase
{
    public Guid TenantId { get; set; }

    protected TenantEntityBase(Guid tenantId)
    {
        TenantId = tenantId;
    }
}