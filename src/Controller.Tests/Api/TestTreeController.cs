namespace Controller.Tests.Api
{
    using Common.Tests.TestHelpers;
    using Controller.Api;
    using Controller.ViewModels.Tree;
    using NUnit.Framework;
    using Repository.Entities;

    [TestFixture]
    public class TestTreeController : IDisposable
    {
        private TestEntityHelper _testEntityHelper = null!;
        private TreeController _treeController = null!;

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
            Assert.Multiple(() =>
            {
                Assert.That(value.Id, Is.EqualTo(tree.Id));
                Assert.That(value.Label, Is.EqualTo(tree.Label));
            });
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool dispose)
        {
            _testEntityHelper.Dispose();
        }
    }
}