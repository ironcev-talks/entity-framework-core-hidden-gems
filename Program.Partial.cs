using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;

namespace EntityFrameworkCoreHiddenGems
{
    public partial class Program
    {
        private static void CreateAndSeedDatabase<TDbContext>(TDbContext context, Action<TDbContext> seedDatabase = null)
            where TDbContext : DbContext
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            seedDatabase?.Invoke(context);
        }

        private static void DisplayDemoStep(string demoStepTitle)
        {
            string border = new string('=', demoStepTitle.Length);

            // Sleep injection :-) Yeee :-) Just to make "sure" logs are displayed on the console in a decent manner.
            Thread.Sleep(111);

            Console.WriteLine();
            Console.WriteLine(border);
            Console.WriteLine(demoStepTitle);
            Console.WriteLine(border);
            Console.WriteLine();
        }
    }
}
