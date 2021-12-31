namespace Repository.Entities
{
    using System.Collections.Generic;
    using Repository.Entities.Base;

    public class Tree : TenantEntityBase
    {
        public string Label { get; set; }

        public List<Node> Nodes { get; }

        public Tree(string label)
        {
            Label = label;
            Nodes = new List<Node>();
        }
    }
}