namespace Controller.Base
{
    public abstract class ViewModelBase
    {
        public Guid Id { get; set; }

        public DateTime CreationDate { get; set; }
    }
}