namespace Controller.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Repository.Entities;

    public static class NodeHelper
    {
        public static void PrettyPrintTree(StringBuilder builder, Tree tree)
        {
            HashSet<Guid> displayedNodes = new HashSet<Guid>();
            builder.Append(tree.Label);

            for (int i = 0; i < tree.Nodes.Count; i++)
            {
                PrettyPrintNode(displayedNodes, builder, tree.Nodes[i], null, 0, i == tree.Nodes.Count - 1);
            }
        }

        public static void PrettyPrintNode(HashSet<Guid> displayedNodes, StringBuilder builder, Node node, Guid? parentNodeId, int nodeLevel, bool isLastNode)
        {
            builder.Append(Environment.NewLine);
            builder.Append(new string(' ', 4 * nodeLevel));
            builder.Append(isLastNode ? "└── " : "├── ");
            builder.Append(node.Label);

            if (!displayedNodes.Contains(node.Id))
            {
                displayedNodes.Add(node.Id);

                for (int i = 0; i < node.Children.Count; i++)
                {
                    PrettyPrintNode(displayedNodes, builder, node.Children[i], node.Id, nodeLevel + 1, i == node.Children.Count - 1);
                }
            }
        }
    }
}