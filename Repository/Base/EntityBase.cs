namespace Repository.Base
{
    using System;

    public abstract class EntityBase
    {
        public long Id { get; set; }

        public Guid Uuid { get; set; }
    }
}