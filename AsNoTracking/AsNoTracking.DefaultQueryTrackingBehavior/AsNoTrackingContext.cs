using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AsNoTracking
{
    public class AsNoTrackingContext : DbContext
    {
        private static readonly ILoggerFactory LoggerFactory
            = Microsoft.Extensions.Logging.LoggerFactory
                .Create(builder =>
                    builder
                        .AddConsole()
                        .AddFilter((s, l) => l == LogLevel.Information && !s.EndsWith("Connection"))
                );

        public DbSet<Author> Authors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EntityFrameworkCoreHiddenGems.AsNoTracking.DefaultQueryTrackingBehavior;Trusted_Connection=True;ConnectRetryCount=0")
                .UseLoggerFactory(LoggerFactory);
        }
    }
}
