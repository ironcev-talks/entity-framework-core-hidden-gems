using System;
using System.Linq;
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
                    SomeDateTime = DateTime.Now.AddYears(-i),
                    SomeGuid = Guid.Empty,
                    SomeInt = -i,
                    SomeDouble = double.MinValue + i,
                });
            }

            context.SaveChanges();

            Console.ReadLine();

            int someInt = -4;
            DisplayDemoStep($"Get the entity with {nameof(SomeEntity.SomeInt)} equals to {someInt}");

            var entity = context.SomeEntities.FirstOrDefault(entity => entity.SomeInt == someInt);
            if (entity is null)
                DisplayText($"The entity with {nameof(SomeEntity.SomeInt)} equals to {someInt} NOT found.");
            else
                DisplayText($"The entity with {nameof(SomeEntity.SomeInt)} equals to {someInt} found.");

            Console.ReadLine();

            someInt = 0;
            DisplayDemoStep($"Get entities with {nameof(SomeEntity.SomeInt)} less then {someInt}");

            var entities = context.SomeEntities.Where(entity => entity.SomeInt < someInt).ToList();
            if (!entities.Any())
                DisplayText($"Entities with {nameof(SomeEntity.SomeInt)} less then {someInt} NOT found.");
            else
                DisplayText($"Entities with {nameof(SomeEntity.SomeInt)} less then {someInt} found.");

            Console.ReadLine();

            DisplayDemoStep($"Add additional entities and get them ordered by {nameof(SomeEntity.SomeInt)}");

            for (int i = 0; i < 5; i++)
            {
                context.SomeEntities.Add(new SomeEntity
                {
                    SomeDateTime = DateTime.Now.AddYears(i),
                    SomeGuid = Guid.Empty,
                    SomeInt = i,
                    SomeDouble = double.MinValue + i,
                });
            }

            context.SaveChanges();

            entities = context.SomeEntities.OrderBy(entity => entity.SomeInt).ToList();

            foreach (var someEntity in entities)
                DisplayText(someEntity.SomeInt.ToString());

            Console.ReadLine();
        }
    }
}
