using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DefiningQueries
{
    public class Program
    {
        private static void Main()
        {
            var db = new DefiningQueriesContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            SetupDatabase();

            Console.Clear();

            var blogPostCounts = db.BlogPostCounts.Where(counts => counts.PostCount > 1).ToList();

            foreach (var blogPost in blogPostCounts)
                Console.WriteLine($"{blogPost.BlogName}\t{blogPost.PostCount}");

            Console.ReadLine();

            void SetupDatabase()
            {
                if (db.Blogs.Any()) return;

                db.Blogs.Add(
                    new Blog
                    {
                        Name = "The Humble Programmer",
                        Url = "http://thehumbleprogrammer.com",
                        Posts = new List<Post>
                        {
                            new Post { Title = "Shakespeare in the Castle Wolfenstein" },
                            new Post { Title = "I Am Only Human After All" },
                            new Post { Title = "Local Functions, Subtle Leaks" },
                            new Post { Title = "Await Async As Async" }
                        }
                    });


                db.SaveChanges();

                db.Database.ExecuteSqlRaw(
                    @"CREATE VIEW View_BlogPostCounts AS 
                            SELECT Name, Count(post.Id) as PostCount from Blogs blog
                            JOIN Posts post on post.Id = blog.Id
                            GROUP BY blog.Name");
            }
        }
    }
}