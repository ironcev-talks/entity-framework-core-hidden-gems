using KeylessEntityTypes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityFrameworkCoreHiddenGems
{
    public partial class Program
    {
        private static void Main()
        {
            var context = new KeylessEntityTypesContext();
            CreateModifyAndSeedDatabase(context, ModifyDatabase, SeedDatabase);

            Console.Clear();

            DisplayDemoStep("Show blogs with more then one post");

            var blogPostCounts = context.BlogPostCounts.Where(counts => counts.NumberOfPosts > 1).ToList();

            foreach (var blogPost in blogPostCounts)
                DisplayText($"{blogPost.BlogTitle}\t{blogPost.NumberOfPosts}");
        }

        private static void SeedDatabase(KeylessEntityTypesContext context)
        {
            context.Blogs.Add(
                new Blog
                {
                    Title = "The Humble Programmer",
                    Url = "http://thehumbleprogrammer.com",
                    Posts = new List<Post>
                    {
                            new Post { Title = "Shakespeare in the Castle Wolfenstein" },
                            new Post { Title = "I Am Only Human After All" },
                            new Post { Title = "Local Functions, Subtle Leaks" },
                            new Post { Title = "Await Async As Async" }
                    }
                });

            context.SaveChanges();
        }

        private static void ModifyDatabase(KeylessEntityTypesContext context)
        {
            context.Database.ExecuteSqlRaw(
                @"CREATE VIEW View_BlogPostCounts AS 
                    SELECT blog.Id, blog.Title, Count(post.Id) as Pst_Count
                    FROM Blogs blog
                    JOIN Posts post on post.BlogId = blog.Id
                    GROUP BY blog.Id, blog.Title");
        }
    }
}
