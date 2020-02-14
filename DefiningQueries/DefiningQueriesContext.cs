using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DefiningQueries
{
    public class DefiningQueriesContext : DbContext
    {
        private static readonly ILoggerFactory LoggerFactory
            = Microsoft.Extensions.Logging.LoggerFactory
                .Create(builder =>
                    builder
                        .AddConsole()
                        .AddFilter((s, l) => l == LogLevel.Information && !s.EndsWith("Connection"))
                );
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        
        public DbSet<BlogPostCount> BlogPostCounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(
                    @"Server=(localdb)\mssqllocaldb;Database=EntityFrameworkCoreHiddenGems.DefiningQueries;Trusted_Connection=True;ConnectRetryCount=0;")
                .UseLoggerFactory(LoggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogPostCount>()
                .HasNoKey()
                .ToQuery(() =>
                    Blogs.Select(blog => new BlogPostCount
                    {
                        BlogName = blog.Name,
                        PostCount = blog.Posts.Count()
                    })
                );
        }
    }
}
