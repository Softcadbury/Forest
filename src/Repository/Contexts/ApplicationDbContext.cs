namespace Repository.Contexts;

using System.Linq.Expressions;
using Common.Misc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.DependencyInjection;
using Repository.Entities;
using Repository.Entities.Base;

public class ApplicationDbContext : IdentityDbContext<
    User,
    IdentityRole<Guid>,
    Guid,
    IdentityUserClaim<Guid>,
    IdentityUserRole<Guid>,
    IdentityUserLogin<Guid>,
    IdentityRoleClaim<Guid>,
    IdentityUserToken<Guid>>
{
    private readonly IServiceProvider _serviceProvider;

    private bool HasSaved { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IServiceProvider serviceProvider)
        : base(options)
    {
        _serviceProvider = serviceProvider;
    }

    public DbSet<Tenant> Tenants { get; set; } = null!;

    public DbSet<Tree> Trees { get; set; } = null!;

    public DbSet<Node> Nodes { get; set; } = null!;

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        ThrowIfMultipleSaves();
        ThrowIfMultitenants();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        ThrowIfMultipleSaves();
        ThrowIfMultitenants();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    /// <summary>
    /// Allows multiple calls to SaveChangesAsync in a same scope (no call to ThrowIfMultipleSaves)
    /// </summary>
    public Task<int> MultipleSaveChangesAsync()
    {
        ThrowIfMultitenants();
        return base.SaveChangesAsync(true);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        ConfigureTenantEntityBaseEntities(builder);
        ConfigureEntityBaseEntities(builder);
    }

    private void ConfigureTenantEntityBaseEntities(ModelBuilder builder)
    {
        // Add tenant filter
        IEnumerable<Type> tenantEntities = builder.Model.GetEntityTypes().Select(p => p.ClrType).Where(p => typeof(TenantEntityBase).IsAssignableFrom(p));
        Expression<Func<TenantEntityBase, bool>> tenantFilter = p => p.TenantId == GetCurrentTenantId();

        foreach (Type type in tenantEntities)
        {
            ParameterExpression parameter = Expression.Parameter(type);
            Expression expression = ReplacingExpressionVisitor.Replace(tenantFilter.Parameters.Single(), parameter, tenantFilter.Body);
            builder.Entity(type).HasQueryFilter(Expression.Lambda(expression, parameter));
        }
    }

    private static void ConfigureEntityBaseEntities(ModelBuilder builder)
    {
        // Set CreationDate at entity creation
        IEnumerable<Type> entityTypes = builder.Model.GetEntityTypes().Select(p => p.ClrType).Where(p => typeof(EntityBase).IsAssignableFrom(p));

        foreach (Type type in entityTypes)
        {
            builder.Entity(type).Property(typeof(DateTime), "CreationDate").HasDefaultValueSql("GETUTCDATE()");
        }
    }

    private void ThrowIfMultipleSaves()
    {
#if DEBUG
        IHttpContextAccessor? httpContextAccessor = _serviceProvider.GetService<IHttpContextAccessor>();

        if (httpContextAccessor?.HttpContext == null)
        {
            return;
        }

        if (HasSaved)
        {
            throw new MultipleSavesException("You should not call SaveChanges or SaveChangesAsync two times in the same http request.");
        }

        HasSaved = true;
#endif
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