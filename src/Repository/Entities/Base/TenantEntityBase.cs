namespace Repository.Entities.Base
{
    using System;

    public abstract class TenantEntityBase : EntityBase
    {
        public Guid TenantId { get; set; }
    }
}