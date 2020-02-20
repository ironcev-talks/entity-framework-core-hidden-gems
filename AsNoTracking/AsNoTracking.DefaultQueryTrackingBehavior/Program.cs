using System;

namespace AsNoTracking
{
    public class Program
    {
        private static void Main()
        {
            var context = new AsNoTrackingContext();
            CreateAndSeedDatabase();

            Console.Clear();

            var authorService = new AuthorService(context);

            Console.WriteLine("---- Get authors. ----");

            foreach (var author in authorService.GetAuthors())
                Console.WriteLine(author.FullName);

            Console.WriteLine("---- Do something with authors. ----");

            authorService.DoSomethingWithAuthors();

            Console.WriteLine();

            Console.WriteLine("---- Get authors again. ----");

            foreach (var author in authorService.GetAuthors())
                Console.WriteLine(author.FullName);

            void CreateAndSeedDatabase()
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                SeedDatabase();

                void SeedDatabase()
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

                    context.SaveChanges();
                }
            }
        }
    }
}
