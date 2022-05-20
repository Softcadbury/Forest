namespace Common.Tests.Base;

using Common.Misc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Repository.Contexts;
using Repository.Entities;

public abstract class SqlIntegrationTestBase : IDisposable
{
    protected CurrentContext CurrentContext { get; private set; } = null!;

    protected ApplicationDbContext ApplicationDbContext { get; private set; } = null!;

    [SetUp]
    public async Task SetUpSqlIntegrationTestBase()
    {
        DbContextOptions<ApplicationDbContext> options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
        var serviceCollection = new ServiceCollection();
        await using ApplicationDbContext contextWithoutTenant = new ApplicationDbContext(options, serviceCollection.BuildServiceProvider());

        string tenantName = Guid.NewGuid().ToString();
        Tenant? tenant = contextWithoutTenant.Tenants.SingleOrDefault(p => p.Name == tenantName);

        if (tenant == null)
        {
            tenant = new Tenant(tenantName);
            contextWithoutTenant.Tenants.Add(tenant);
            await contextWithoutTenant.SaveChangesAsync();
        }

        CurrentContext = new CurrentContext { TenantId = tenant.Id };
        serviceCollection.AddScoped(_ => CurrentContext);

        ApplicationDbContext = new ApplicationDbContext(options, serviceCollection.BuildServiceProvider());
    }

    protected async Task<Tree> CreateTree(string? label = null)
    {
        label ??= Guid.NewGuid().ToString();

        Tree tree = new Tree(CurrentContext.TenantId, label);
        ApplicationDbContext.Trees.Add(tree);
        await ApplicationDbContext.SaveChangesAsync();

        return tree;
    }

    protected async Task<Node> CreateNode(Guid? treeId = null, string? label = null)
    {
        if (treeId == null)
        {
            Tree tree = await CreateTree();
            treeId = tree.Id;
        }

        label ??= Guid.NewGuid().ToString();

        Node node = new Node(CurrentContext.TenantId, treeId.Value, label);
        ApplicationDbContext.Nodes.Add(node);
        await ApplicationDbContext.SaveChangesAsync();

        return node;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool dispose)
    {
        ApplicationDbContext.Dispose();
    }
}