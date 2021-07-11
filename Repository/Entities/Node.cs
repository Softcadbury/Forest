namespace Repository.Entities
{
    using System;
    using Repository.Base;

    public class Node : EntityBase
    {
        public Tree Tree { get; set; } = null!;

        public Guid TreeId { get; set; }

        public string Label { get; set; }

        public Node(Guid treeId, string label)
        {
            TreeId = treeId;
            Label = label;
        }
    }
}