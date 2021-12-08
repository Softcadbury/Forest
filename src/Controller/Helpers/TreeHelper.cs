namespace Controller.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Repository.Entities;

    public static class TreeHelper
    {
        public static string PrettyPrintTree(Tree tree)
        {
            var builder = new StringBuilder();
            var nodes = new List<(Node Node, int Level, bool IsLast)>();
            var alreadyDisplayedNodes = new HashSet<Guid>();

            builder.Append(tree.Label);

            for (int i = 0; i < tree.Nodes.Count; i++)
            {
                AddCurrentNode(nodes, node: tree.Nodes[i], level: 0, isLast: i == tree.Nodes.Count - 1);
                PrettyPrintNode(builder, nodes, alreadyDisplayedNodes);
            }

            return builder.ToString();
        }

        private static void PrettyPrintNode(StringBuilder builder, List<(Node Node, int Level, bool IsLast)> nodes, HashSet<Guid> alreadyDisplayedNodes)
        {
            (Node currentNode, int currentNodeLevel, bool isCurrentNodeLast) = nodes.Last();
            AppendCurrentNode(builder, nodes, currentNode, isCurrentNodeLast);

            if (alreadyDisplayedNodes.Contains(currentNode.Id))
            {
                return;
            }

            alreadyDisplayedNodes.Add(currentNode.Id);

            for (int i = 0; i < currentNode.Children.Count; i++)
            {
                AddCurrentNode(nodes, node: currentNode.Children[i], level: currentNodeLevel + 1, isLast: i == currentNode.Children.Count - 1);
                PrettyPrintNode(builder, nodes, alreadyDisplayedNodes);
            }
        }

        private static void AddCurrentNode(List<(Node Node, int Level, bool IsLast)> nodeLevels, Node node, int level, bool isLast)
        {
            int numberOfNodesToRemove = nodeLevels.Count - level;
            if (numberOfNodesToRemove > 0)
            {
                nodeLevels.RemoveRange(level, numberOfNodesToRemove);
            }

            nodeLevels.Add((node, level, isLast));
        }

        private static void AppendCurrentNode(StringBuilder builder, List<(Node Node, int Level, bool IsLast)> nodes, Node currentNode, bool isCurrentNodeLast)
        {
            builder.Append(Environment.NewLine);

            for (int i = 0; i < nodes.Count - 1; i++)
            {
                builder.Append(nodes[i].IsLast ? " " : "|");
                builder.Append("   ");
            }

            builder.Append(isCurrentNodeLast ? "└── " : "├── ");
            builder.Append(currentNode.Label);
        }
    }
}