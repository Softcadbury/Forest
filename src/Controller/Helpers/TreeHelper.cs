namespace Controller.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Repository.Entities;

    public static class TreeHelper
    {
        public static void PrettyPrintTree(StringBuilder builder, Tree tree)
        {
            HashSet<Guid> alreadyDisplayedNodes = new HashSet<Guid>();
            builder.Append(tree.Label);

            for (int i = 0; i < tree.Nodes.Count; i++)
            {
                PrettyPrintNode(builder, tree.Nodes[i], 0, i == tree.Nodes.Count - 1, alreadyDisplayedNodes);
            }
        }

        private static void PrettyPrintNode(StringBuilder builder, Node node, int nodeLevel, bool isLastNode, HashSet<Guid> alreadyDisplayedNodes)
        {
            builder.Append(Environment.NewLine);
            builder.Append(new string(' ', 4 * nodeLevel));
            builder.Append(isLastNode ? "└── " : "├── ");
            builder.Append(node.Label);

            if (!alreadyDisplayedNodes.Contains(node.Id))
            {
                alreadyDisplayedNodes.Add(node.Id);

                for (int i = 0; i < node.Children.Count; i++)
                {
                    PrettyPrintNode(builder, node.Children[i], nodeLevel + 1, i == node.Children.Count - 1, alreadyDisplayedNodes);
                }
            }
        }
    }
}