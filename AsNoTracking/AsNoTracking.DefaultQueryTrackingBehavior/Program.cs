using System;

namespace AsNoTracking
{
    public class Program
    {
        private static void Main()
        {
            var context = new AsNoTrackingContext();
            CreateAndSeedDatabase();

            var customerService = new AuthorService(context);

            foreach (var customer in customerService.GetAuthors())
                Console.WriteLine(customer.FirstName);

            customerService.DoSomethingWithAuthors();

            Console.WriteLine();

            foreach (var customer in customerService.GetAuthors())
                Console.WriteLine(customer.FirstName);

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
                            FirstName = "Ana",
                            LastName = "Kirin"
                        });

                    context.Authors.Add(
                        new Author
                        {
                            FirstName = "Nermina",
                            LastName = "Kirin"
                        });

                    context.SaveChanges();
                }
            }
        }
    }
}
