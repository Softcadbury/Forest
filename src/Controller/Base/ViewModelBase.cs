namespace Controller.Base
{
    using System;

    public abstract class ViewModelBase
    {
        public Guid Uuid { get; set; }

        public DateTime CreationDate { get; set; }
    }
}