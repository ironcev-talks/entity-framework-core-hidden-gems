using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KeylessEntityTypes
{
    public class KeylessEntityTypesContext : DbContext
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

        // public DbQuery<BlogPostCount> BlogPostCounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(
                    @"Server=(localdb)\mssqllocaldb;Database=EntityFrameworkCoreHiddenGems.KeylessEntityTypes;Trusted_Connection=True;ConnectRetryCount=0;")
                .UseLoggerFactory(LoggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogPostCount>()
                .HasNoKey()
                .ToView("View_BlogPostCounts")
                .Property(v => v.BlogName).HasColumnName("Name");

            // modelBuilder.Query<BlogPostCount>()
            //    .ToView("View_BlogPostCounts")
            //    .Property(v => v.BlogName).HasColumnName("Name");
        }
    }
}
