namespace Controller.Tests.Api
{
    using Common.Tests.TestHelpers;
    using Controller.Api;
    using Controller.ViewModels.Tree;
    using NUnit.Framework;
    using Repository.Entities;

    [TestFixture]
    public class TestTreeController
    {
        private TestEntityHelper _testEntityHelper;
        private TreeController _treeController;

        [SetUp]
        public void Setup()
        {
            _testEntityHelper = new TestEntityHelper();
            _treeController = new TreeController(_testEntityHelper.ApplicationDbContext, _testEntityHelper.CurrentContext, TestHelper.GetAutoMapper());
        }

        [Test]
        public async Task TreeController_Get_TreeInDatabase_ReturnTree()
        {
            // Arrange
            Tree tree = await _testEntityHelper.CreateTree();

            // Act
            var result = await _treeController.Get(tree.Id);

            // Assert
            TreeViewModel value = result.GetOkContent();
            Assert.That(value.Id, Is.EqualTo(tree.Id));
            Assert.That(value.Label, Is.EqualTo(tree.Label));
        }
    }
}