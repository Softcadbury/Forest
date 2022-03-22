namespace Common.Tests.Base
{
    using Common.Misc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using NUnit.Framework;
    using Repository.Contexts;
    using Repository.Entities;

    public abstract class SqlIntegrationTestBase : IDisposable
    {
        public CurrentContext CurrentContext { get; private set; } = null!;

        public ApplicationDbContext ApplicationDbContext { get; private set; } = null!;

        [SetUp]
        public void SetUp()
        {
            DbContextOptions<ApplicationDbContext> options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            var serviceCollection = new ServiceCollection();
            using ApplicationDbContext context = new ApplicationDbContext(options, serviceCollection.BuildServiceProvider());

            string tenantName = Guid.NewGuid().ToString();
            Tenant? tenant = context.Tenants.SingleOrDefault(p => p.Name == tenantName);

            if (tenant == null)
            {
                tenant = new Tenant(tenantName);
                context.Tenants.Add(tenant);
                context.SaveChanges();
            }

            CurrentContext = new CurrentContext
            {
                TenantId = tenant.Id,
            };

            serviceCollection.AddScoped(_ => CurrentContext);
            ApplicationDbContext = new ApplicationDbContext(options, serviceCollection.BuildServiceProvider());
        }

        public async Task<Tree> CreateTree(string? label = null)
        {
            label ??= Guid.NewGuid().ToString();

            Tree tree = new Tree(CurrentContext.TenantId, label);
            ApplicationDbContext.Trees.Add(tree);
            await ApplicationDbContext.SaveChangesAsync();

            return tree;
        }

        public async Task<Node> CreateNode(Guid? treeId = null, string? label = null)
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
}