namespace Repository.Contexts
{
    using System.Linq.Expressions;
    using Common.Misc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Query;
    using Microsoft.Extensions.DependencyInjection;
    using Repository.Entities;
    using Repository.Entities.Base;

    public class Context : DbContext
    {
        private readonly IServiceProvider _serviceProvider;

        public Context(DbContextOptions<Context> options, IServiceProvider serviceProvider)
            : base(options)
        {
            _serviceProvider = serviceProvider;
        }

        public DbSet<User> Users { get; set; } = null!;

        public DbSet<Tenant> Tenants { get; set; } = null!;

        public DbSet<Tree> Trees { get; set; } = null!;

        public DbSet<Node> Nodes { get; set; } = null!;

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            ThrowIfMultitenants();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            ThrowIfMultitenants();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ConfigureTenantEntityBaseEntities(modelBuilder);
            ConfigureEntityBaseEntities(modelBuilder);
        }

        private void ConfigureTenantEntityBaseEntities(ModelBuilder modelBuilder)
        {
            // Add tenant filter
            IEnumerable<Type> tenantEntities = modelBuilder.Model.GetEntityTypes().Select(p => p.ClrType).Where(p => typeof(TenantEntityBase).IsAssignableFrom(p));
            Expression<Func<TenantEntityBase, bool>> tenantFilter = p => p.TenantId == GetCurrentTenantId();

            foreach (Type type in tenantEntities)
            {
                ParameterExpression parameter = Expression.Parameter(type);
                Expression expression = ReplacingExpressionVisitor.Replace(tenantFilter.Parameters.Single(), parameter, tenantFilter.Body);
                modelBuilder.Entity(type).HasQueryFilter(Expression.Lambda(expression, parameter));
            }
        }

        private static void ConfigureEntityBaseEntities(ModelBuilder modelBuilder)
        {
            // Set CreationDate at entity creation
            IEnumerable<Type> entityTypes = modelBuilder.Model.GetEntityTypes().Select(p => p.ClrType).Where(p => typeof(EntityBase).IsAssignableFrom(p));

            foreach (Type type in entityTypes)
            {
                modelBuilder.Entity(type).Property(typeof(DateTime), "CreationDate").HasDefaultValueSql("GETUTCDATE()");
            }
        }

        private void ThrowIfMultitenants()
        {
            Guid[] tenantIds = ChangeTracker.Entries()
                .Where(p => p.Entity is TenantEntityBase)
                .Select(p => ((TenantEntityBase)p.Entity).TenantId)
                .Distinct().ToArray();

            if (tenantIds.Length == 0)
            {
                return;
            }

            Guid currentTenantId = GetCurrentTenantId();

            if (tenantIds.Length > 1 || tenantIds.First() != currentTenantId)
            {
                throw new CrossTenantUpdateException(currentTenantId, tenantIds);
            }
        }

        private Guid GetCurrentTenantId()
        {
            return ((CurrentContext)_serviceProvider.GetRequiredService(typeof(CurrentContext))).TenantId;
        }
    }
}