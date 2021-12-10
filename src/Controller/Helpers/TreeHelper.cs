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

            builder.Append(tree.Label);

            for (int i = 0; i < tree.Nodes.Count; i++)
            {
                AddNodeToBranch(nodes, node: tree.Nodes[i], level: 0, isLast: i == tree.Nodes.Count - 1);
                PrettyPrintNode(builder, nodes);
            }

            return builder.ToString();
        }

        private static void PrettyPrintNode(StringBuilder builder, List<(Node Node, int Level, bool IsLast)> branch)
        {
            (Node node, int nodeLevel, bool isNodeLast) = branch.Last();
            AppendNodeToStringBuilder(builder, branch, isNodeLast);

            bool isNodeAlreadyDisplayed = branch.Take(branch.Count - 1).Select(p => p.Node.Id).Contains(node.Id);
            if (isNodeAlreadyDisplayed)
            {
                var infiniteNode = new Node(Guid.NewGuid(), "[...]");
                AddNodeToBranch(branch, node: infiniteNode, level: nodeLevel + 1, isLast: isNodeLast);
                AppendNodeToStringBuilder(builder, branch, isNodeLast);
                return;
            }

            for (int i = 0; i < node.Children.Count; i++)
            {
                AddNodeToBranch(branch, node: node.Children[i], level: nodeLevel + 1, isLast: i == node.Children.Count - 1);
                PrettyPrintNode(builder, branch);
            }
        }

        private static void AddNodeToBranch(List<(Node Node, int Level, bool IsLast)> branch, Node node, int level, bool isLast)
        {
            int numberOfNodesToRemove = branch.Count - level;
            if (numberOfNodesToRemove > 0)
            {
                branch.RemoveRange(level, numberOfNodesToRemove);
            }

            branch.Add((node, level, isLast));
        }

        private static void AppendNodeToStringBuilder(StringBuilder builder, List<(Node Node, int Level, bool IsLast)> branch, bool isNodeLast)
        {
            builder.Append(Environment.NewLine);

            for (int i = 0; i < branch.Count - 1; i++)
            {
                builder.Append(branch[i].IsLast ? " " : "|");
                builder.Append("   ");
            }

            builder.Append(isNodeLast ? "└── " : "├── ");
            builder.Append(branch[^1].Node.Label);
        }
    }
}