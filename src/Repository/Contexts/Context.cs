namespace Repository.Contexts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Query;
    using Repository.Entities;
    using Repository.Entities.Base;

    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<Node> Tenants { get; set; } = null!;

        public DbSet<Tree> Trees { get; set; } = null!;

        public DbSet<Node> Nodes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // AddTenantFilters(modelBuilder);

            IEnumerable<Type> entityTypes = modelBuilder.Model.GetEntityTypes().Select(p => p.ClrType).Where(p => typeof(EntityBase).IsAssignableFrom(p));
            foreach (Type type in entityTypes)
            {
                modelBuilder.Entity(type).Property(typeof(DateTime), "CreationDate").HasDefaultValueSql("GETUTCDATE()");
            }
        }

        private static void AddTenantFilters(ModelBuilder modelBuilder)
        {
            IEnumerable<Type> tenantEntities = modelBuilder.Model.GetEntityTypes().Select(p => p.ClrType).Where(p => typeof(TenantEntityBase).IsAssignableFrom(p));
            Expression<Func<TenantEntityBase, bool>> tenantFilter = p => p.TenantId == Guid.Empty; // todo - use correct guid

            foreach (Type type in tenantEntities)
            {
                ParameterExpression parameter = Expression.Parameter(type);
                Expression expression = ReplacingExpressionVisitor.Replace(tenantFilter.Parameters.Single(), parameter, tenantFilter.Body);
                modelBuilder.Entity(type).HasQueryFilter(Expression.Lambda(expression, parameter));
            }
        }
    }
}