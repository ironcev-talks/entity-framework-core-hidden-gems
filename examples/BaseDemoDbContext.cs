using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace EntityFrameworkCoreHiddenGems
{
    public class BaseDemoDbContext : DbContext
    {
        private static readonly ILoggerFactory LoggerFactory
            = Microsoft.Extensions.Logging.LoggerFactory
                .Create(builder =>
                    builder
                        .AddConsole()
                        .AddFilter((s, l) => (l == LogLevel.Information || l == LogLevel.Warning) && !s.EndsWith("Connection"))
                );

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string databaseName = Assembly.GetExecutingAssembly().GetName().Name;
            optionsBuilder
                .UseSqlServer($@"Server=(localdb)\mssqllocaldb;Database={databaseName};Trusted_Connection=True;ConnectRetryCount=0")
                .UseLoggerFactory(LoggerFactory);
        }
    }
}
