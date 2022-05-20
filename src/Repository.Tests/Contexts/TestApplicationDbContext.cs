namespace Repository.Tests.Contexts;

using Common.Misc;
using Common.Tests.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using NUnit.Framework;
using Repository.Contexts;
using Repository.Entities;

[TestFixture]
public class TestApplicationDbContext : SqlIntegrationTestBase
{
    [Test]
    public async Task ApplicationDbContext_SaveChangesAsync_GoodTenantTenant_NoException()
    {
        // Arrange
        Tree tree = new Tree(CurrentContext.TenantId, Guid.NewGuid().ToString());
        ApplicationDbContext.Trees.Add(tree);

        // Act
        await ApplicationDbContext.SaveChangesAsync();

        // Assert
        List<Tree> trees = await ApplicationDbContext.Trees.ToListAsync();
        Assert.That(trees, Has.Count.EqualTo(1));
        Assert.That(trees[0].Id, Is.EqualTo(tree.Id));
    }

#if DEBUG

    [Test]
    public async Task ApplicationDbContext_SaveChangesAsync_CallSeveralTimes_ThrowException([Values] bool testAsync)
    {
        // Arrange
        DbContextOptions<ApplicationDbContext> options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
        var serviceCollection = new ServiceCollection();
        await using ApplicationDbContext contextWithoutTenant = new ApplicationDbContext(options, serviceCollection.BuildServiceProvider());

        var tenant = new Tenant(Guid.NewGuid().ToString());
        contextWithoutTenant.Tenants.Add(tenant);
        await contextWithoutTenant.SaveChangesAsync();

        var currentContext = new CurrentContext { TenantId = tenant.Id };
        serviceCollection.AddScoped(_ => currentContext);

        var httpContextAccessor = Substitute.For<IHttpContextAccessor>();
        serviceCollection.AddScoped(_ => httpContextAccessor);

        await using var applicationDbContext = new ApplicationDbContext(options, serviceCollection.BuildServiceProvider());

        Tree tree = new Tree(currentContext.TenantId, Guid.NewGuid().ToString());
        applicationDbContext.Trees.Add(tree);

        // Act & Assert
        if (testAsync)
        {
            await applicationDbContext.SaveChangesAsync();
            Assert.ThrowsAsync<MultipleSavesException>(() => applicationDbContext.SaveChangesAsync());
        }
        else
        {
            applicationDbContext.SaveChanges();
            Assert.Throws<MultipleSavesException>(() => applicationDbContext.SaveChanges());
        }
    }

#endif

    [Test]
    public void ApplicationDbContext_SaveChangesAsync_SaveWithMultipleTenants_ThrowException([Values] bool testAsync)
    {
        // Arrange
        Tree tree1 = new Tree(CurrentContext.TenantId, Guid.NewGuid().ToString());
        ApplicationDbContext.Trees.Add(tree1);
        Tree tree2 = new Tree(Guid.NewGuid(), Guid.NewGuid().ToString());
        ApplicationDbContext.Trees.Add(tree2);

        // Act & Assert
        if (testAsync)
        {
            Assert.ThrowsAsync<CrossTenantUpdateException>(() => ApplicationDbContext.SaveChangesAsync());
        }
        else
        {
            Assert.Throws<CrossTenantUpdateException>(() => ApplicationDbContext.SaveChanges());
        }
    }

    [Test]
    public void ApplicationDbContext_SaveChangesAsync_SaveWithDifferentTenant_ThrowException([Values] bool testAsync)
    {
        // Arrange
        Tree tree = new Tree(Guid.NewGuid(), Guid.NewGuid().ToString());
        ApplicationDbContext.Trees.Add(tree);

        // Act & Assert
        if (testAsync)
        {
            Assert.ThrowsAsync<CrossTenantUpdateException>(() => ApplicationDbContext.SaveChangesAsync());
        }
        else
        {
            Assert.Throws<CrossTenantUpdateException>(() => ApplicationDbContext.SaveChanges());
        }
    }
}