using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;

namespace EntityFrameworkCoreHiddenGems
{
    public partial class Program
    {
        private static void CreateDatabase<TDbContext>(TDbContext context)
            where TDbContext : DbContext
        {
            CreateModifyAndSeedDatabase(context, null, null);
        }

        private static void CreateAndSeedDatabase<TDbContext>(TDbContext context, Action<TDbContext> seedDatabase)
            where TDbContext : DbContext
        {
            CreateModifyAndSeedDatabase(context, seedDatabase, null);
        }

        private static void CreateModifyAndSeedDatabase<TDbContext>(TDbContext context, Action<TDbContext> modifyDatabase, Action<TDbContext> seedDatabase)
            where TDbContext : DbContext
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            modifyDatabase?.Invoke(context);
            seedDatabase?.Invoke(context);
        }

        private static void DisplayDemoStep(string demoStepTitle)
        {
            string border = new string('=', demoStepTitle.Length);

            // Sleep injection :-) Yeee :-) Just to make "sure" logs are displayed on the console in a decent manner.
            Thread.Sleep(111);

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine();
            Console.WriteLine(border);
            Console.WriteLine(demoStepTitle);
            Console.WriteLine(border);
            Console.WriteLine();

            Console.ResetColor();
        }

        private static void DisplayText(string text)
        {
            Thread.Sleep(11);

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine(text);

            Console.ResetColor();
        }
    }
}
