using System;
using ValueConversions;

namespace EntityFrameworkCoreHiddenGems
{
    public partial class Program
    {
        private static void Main()
        {
            var context = new ValueConversionsContext();
            CreateDatabase(context);

            Console.Clear();

            DisplayDemoStep("Add a few entities to the database");

            for (int i = 0; i < 5; i++)
            {
                context.SomeEntities.Add(new SomeEntity
                {
                    SomeDateTime = DateTime.Now,
                    SomeGuid = Guid.NewGuid(),
                    SomeInt = new Random().Next(1_000_000),
                    SomeDouble = new Random().NextDouble() * 10_000,
                    SomeEnum = (SomeEnum)new Random().Next(3),
                    SomeFlagsEnum = SomeFlagsEnum.First | SomeFlagsEnum.Second
                });
            }

            context.SaveChanges();

            Console.ReadLine();
        }
    }
}
