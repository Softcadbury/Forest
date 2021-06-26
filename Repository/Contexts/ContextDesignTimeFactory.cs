namespace Repository.Contexts
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;

    /// <summary>
    /// Create context to generate EF migrations
    /// </summary>
    public class ContextDesignTimeFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {
            const string connectionString = "Server=.;Database=Steiner;Trusted_Connection=True;ConnectRetryCount=0";
            DbContextOptions<Context> options = new DbContextOptionsBuilder<Context>().UseSqlServer(connectionString).Options;

            return new Context(options);
        }
    }
}