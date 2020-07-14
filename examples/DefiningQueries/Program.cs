using DefiningQueries;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityFrameworkCoreHiddenGems
{
    public partial class Program
    {
        private static void Main()
        {
            var context = new DefiningQueriesContext();
            CreateAndSeedDatabase(context, SeedDatabase);

            Console.Clear();

            DisplayDemoStep("Show blogs with more then one post");

            var blogPostCounts = context.BlogPostCounts.Where(counts => counts.NumberOfPosts > 1).ToList();

            foreach (var blogPost in blogPostCounts)
                DisplayText($"{blogPost.BlogTitle}\t{blogPost.NumberOfPosts}");
        }

        private static void SeedDatabase(DefiningQueriesContext context)
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
    }
}
