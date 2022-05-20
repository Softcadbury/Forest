namespace Repository.Entities;

using Repository.Entities.Base;

public class Tree : TenantEntityBase
{
    public string Label { get; set; }

    public List<Node> Nodes { get; }

    public Tree(Guid tenantId, string label)
        : base(tenantId)
    {
        Label = label;
        Nodes = new List<Node>();
    }
}