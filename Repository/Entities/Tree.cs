namespace Repository.Entities
{
    using System.Collections.Generic;
    using Repository.Base;

    public class Tree : EntityBase
    {
        public string Label { get; set; }

        public List<Node> Nodes { get; set; }

        public Tree(string label)
        {
            Label = label;
            Nodes = new List<Node>();
        }
    }
}