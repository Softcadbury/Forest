namespace Repository.Contexts
{
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Repository.Entities;
    using Repository.Entities.Base;

    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<Tree> Trees { get; set; } = null!;

        public DbSet<Node> Nodes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (Type type in modelBuilder.Model
                                    .GetEntityTypes()
                                    .Select(e => e.ClrType)
                                    .Where(t => typeof(EntityBase).IsAssignableFrom(t)))
            {
                modelBuilder.Entity(type).Property(typeof(DateTime), "CreationDate").HasDefaultValueSql("GETUTCDATE()");
            }
        }
    }
}