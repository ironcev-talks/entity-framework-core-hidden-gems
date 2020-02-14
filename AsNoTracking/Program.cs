using System;

namespace AsNoTracking
{
    public class Program
    {
        private static void Main()
        {
            var db = new AsNoTrackingContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            SeedDatabase();

            //var customerService = new CustomersServiceWithTracking(db);
            var customerService = new CustomersServiceWithExplicitNoTracking(db);
            //var customerService = new CustomersServiceWithDefaultQueryTrackingBehaviorNoTracking(db);

            foreach (var customer in customerService.GetCustomers())
                Console.WriteLine(customer.FirstName);

            customerService.DoSomethingWithCustomers();

            Console.WriteLine();

            foreach (var customer in customerService.GetCustomers())
                Console.WriteLine(customer.FirstName);

            void SeedDatabase()
            {
                db.Customers.Add(
                    new Customer
                    {
                        FirstName = "Ana",
                        LastName = "Kirin"
                    });

                db.Customers.Add(
                    new Customer
                    {
                        FirstName = "Nermina",
                        LastName = "Kirin"
                    });

                db.SaveChanges();
            }
        }
    }
}
