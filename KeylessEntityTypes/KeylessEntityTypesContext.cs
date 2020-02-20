using EntityFrameworkCoreHiddenGems;
using Microsoft.EntityFrameworkCore;

namespace KeylessEntityTypes
{
    public class KeylessEntityTypesContext : BaseDemoDbContext
    {
        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<BlogPostCount> BlogPostCounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogPostCount>()
                .HasNoKey()
                .ToView("View_BlogPostCounts");

            modelBuilder.Entity<BlogPostCount>()
                .Property(x => x.BlogId).HasColumnName("Id");

            modelBuilder.Entity<BlogPostCount>()
                .Property(v => v.BlogTitle).HasColumnName("Title");

            modelBuilder.Entity<BlogPostCount>()
                .Property(v => v.NumberOfPosts).HasColumnName("Pst_Count");
        }
    }
}
