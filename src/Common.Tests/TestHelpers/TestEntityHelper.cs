namespace Common.Tests.TestHelpers
{
    using Common.Misc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Repository.Contexts;
    using Repository.Entities;

    public class TestEntityHelper : IDisposable
    {
        public CurrentContext CurrentContext { get; }

        public ApplicationDbContext ApplicationDbContext { get; }

        public TestEntityHelper(string? tenantName = null)
        {
            DbContextOptions<ApplicationDbContext> options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            var serviceCollection = new ServiceCollection();
            using ApplicationDbContext context = new ApplicationDbContext(options, serviceCollection.BuildServiceProvider());

            tenantName ??= Guid.NewGuid().ToString();
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