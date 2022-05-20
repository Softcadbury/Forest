namespace Controller.Tests.Api;

using Common.Tests.Base;
using Common.Tests.TestHelpers;
using Controller.Api;
using Controller.ViewModels.Tree;
using NUnit.Framework;
using Repository.Entities;

[TestFixture]
public class TestTreeController : SqlIntegrationTestBase
{
    private TreeController _treeController = null!;

    [SetUp]
    public void Setup()
    {
        _treeController = new TreeController(ApplicationDbContext, CurrentContext, TestHelper.GetAutoMapper());
    }

    [Test]
    public async Task TreeController_Get_TreeInDatabase_ReturnTree()
    {
        // Arrange
        Tree tree = await CreateTree();

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

    [Test]
    public async Task TreeController_GetAll_TreesInDatabase_ReturnTrees()
    {
        // Arrange
        Tree tree1 = await CreateTree();
        Tree tree2 = await CreateTree();

        // Act
        var result = await _treeController.GetAll();

        // Assert
        List<TreeViewModel> value = result.GetOkContent().ToList();
        Assert.That(value, Has.Count.EqualTo(2));
        Assert.Multiple(() =>
        {
            Assert.That(value[0].Id, Is.EqualTo(tree1.Id));
            Assert.That(value[1].Id, Is.EqualTo(tree2.Id));
        });
    }
}