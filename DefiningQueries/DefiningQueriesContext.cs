using EntityFrameworkCoreHiddenGems;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DefiningQueries
{
    public class DefiningQueriesContext : BaseDemoDbContext
    {
        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<BlogPostCount> BlogPostCounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogPostCount>()
                .HasNoKey()
                .ToQuery(() =>
                    Blogs.Select(blog => new BlogPostCount
                    {
                        BlogId = blog.Id,
                        BlogTitle = blog.Title,
                        NumberOfPosts = blog.Posts.Count()
                    })
                );
        }
    }
}
