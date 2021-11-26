namespace Controller.Tests.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Controller.Helpers;
    using NUnit.Framework;
    using Repository.Entities;

    [TestFixture]
    public sealed class TestTreeHelper
    {
        [Test]
        public void TreeHelper_PrettyPrintTree()
        {
            // Arrange
            var tree = CreateTree("tree");

            var nodes = new List<Node>
            {
                CreateNode(
                    tree,
                    "node 1",
                    CreateNode(tree, "node 1.1"),
                    CreateNode(
                        tree,
                        "node 1.2",
                        CreateNode(tree, "node 1.2.1"),
                        CreateNode(tree, "node 1.2.2"))),
                CreateNode(tree, "node 2"),
            };

            tree.Nodes.AddRange(nodes);

            var stringBuilder = new StringBuilder();

            // Act
            TreeHelper.PrettyPrintTree(stringBuilder, tree);
            string result = stringBuilder.ToString();

            // Assert
            string expectedResult =
@"tree
├── node 1
    ├── node 1.1
    └── node 1.2
        ├── node 1.2.1
        └── node 1.2.2
└── node 2";

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void TreeHelper_PrettyPrintTree_WithRecursiveNodes()
        {
            // Arrange
            var tree = CreateTree("tree");

            var recursiveNode1 = CreateNode(tree, "node rec 1");
            var recursiveNode2 = CreateNode(tree, "node rec 2");
            recursiveNode1.Children.Add(recursiveNode1);
            recursiveNode2.Children.Add(recursiveNode1);

            var nodes = new List<Node>
            {
                CreateNode(tree, "node 1", recursiveNode1, recursiveNode2),
                CreateNode(tree, "node 2"),
            };

            tree.Nodes.AddRange(nodes);

            var stringBuilder = new StringBuilder();

            // Act
            TreeHelper.PrettyPrintTree(stringBuilder, tree);
            string result = stringBuilder.ToString();

            // Assert
            string expectedResult =
                @"tree
├── node 1
    ├── node rec 1
        └── node rec 2
            └── node rec 1
    └── node rec 2
└── node 2";

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        private static Tree CreateTree(string label)
        {
            return new Tree(label) { Id = Guid.NewGuid() };
        }

        private static Node CreateNode(Tree tree, string label, params Node[] children)
        {
            var node = new Node(tree.Id, label) { Id = Guid.NewGuid() };
            node.Children.AddRange(children);

            return node;
        }
    }
}