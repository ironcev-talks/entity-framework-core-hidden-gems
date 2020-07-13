using AsNoTracking;
using System;
using System.Collections.Generic;
using System.Threading;

namespace EntityFrameworkCoreHiddenGems
{
    public partial class Program
    {
        private static void Main()
        {
            var context = new AsNoTrackingContext();
            var authorService = new AuthorService(context);
            CreateAndSeedDatabase(context, SeedDatabase);

            Console.Clear();

            DisplayDemoStep("Get authors");

            DisplayAuthorsNames(authorService.GetAuthors());

            Console.ReadKey(true);

            DisplayDemoStep("Do something with authors");

            authorService.DoSomethingWithAuthors();

            Console.ReadKey(true);

            DisplayDemoStep("Get authors again");

            DisplayAuthorsNames(authorService.GetAuthors());
        }

        private static void DisplayAuthorsNames(IEnumerable<Author> authors)
        {
            Thread.Sleep(500); // A quick and dirty way to avoid overlapping of this and EF logging output.

            foreach (var author in authors)
                Console.WriteLine(author.FullName);
        }

        private static void SeedDatabase(AsNoTrackingContext context)
        {
            context.Authors.Add(
                new Author
                {
                    FirstName = "Ivo",
                    LastName = "Andrić"
                });

            context.Authors.Add(
                new Author
                {
                    FirstName = "Elfriede",
                    LastName = "Jelinek"
                });

            context.Authors.Add(
                new Author
                {
                    FirstName = "Juan",
                    MiddleName = "Ramón",
                    LastName = "Jiménez"
                });

            context.Authors.Add(
                new Author
                {
                    FirstName = "Rabindranath",
                    LastName = "Tagore"
                });

            context.SaveChanges();
        }
    }
}
