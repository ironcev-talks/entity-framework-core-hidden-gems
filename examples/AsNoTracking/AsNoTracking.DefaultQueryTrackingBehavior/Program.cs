using AsNoTracking;
using System;

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

            foreach (var author in authorService.GetAuthors())
                Console.WriteLine(author.FullName);

            DisplayDemoStep("Do something with authors");

            authorService.DoSomethingWithAuthors();

            DisplayDemoStep("Get authors again");

            foreach (var author in authorService.GetAuthors())
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
