namespace Repository.Entities
{
    using System;
    using System.Collections.Generic;
    using Repository.Entities.Base;

    public class Node : TenantEntityBase
    {
        public Tree? Tree { get; set; }

        public Guid TreeId { get; set; }

        public string Label { get; set; }

        public Node? Parent { get; set; }

        public Guid? ParentId { get; set; }

        public List<Node> Children { get; }

        public Node(Guid treeId, string label)
        {
            TreeId = treeId;
            Label = label;
            Children = new List<Node>();
        }
    }
}