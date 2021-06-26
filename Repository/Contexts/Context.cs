namespace Repository.Contexts
{
    using Microsoft.EntityFrameworkCore;
    using Repository.Entities;

    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<Tree> Trees { get; set; } = null!;
    }
}