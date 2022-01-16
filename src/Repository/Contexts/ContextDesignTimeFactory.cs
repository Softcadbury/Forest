namespace Repository.Contexts
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;

    /// <summary>
    /// Create context to generate EF migrations.
    /// </summary>
    public class ContextDesignTimeFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            const string connectionString = "Server=.;Database=Forest;Trusted_Connection=True;ConnectRetryCount=0";
            DbContextOptions<ApplicationDbContext> options = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(connectionString).Options;

            return new ApplicationDbContext(options, null!);
        }
    }
}