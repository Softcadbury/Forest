namespace Repository.Entities;

using Repository.Entities.Base;

public class Tenant : EntityBase
{
    public string Name { get; set; }

    public Tenant(string name)
    {
        Name = name;
    }
}