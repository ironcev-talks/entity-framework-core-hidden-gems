using PersistingAndConstructingEntities;
using System;
using System.Linq;

namespace EntityFrameworkCoreHiddenGems
{
    public partial class Program
    {
        private static void Main()
        {
            var context = new PersistingAndConstructingEntitiesContext();
            CreateDatabase(context);

            Console.Clear();

            DisplayDemoStep("Creating entities");

            var newEntityWithRichProperties = new EntityWithRichProperties();
            newEntityWithRichProperties.SomePropertyWithRichLogic = 123456789;
            newEntityWithRichProperties.SomeOtherPropertyWithRichLogic = -987654321;

            var entityWithoutProperties = new EntityWithoutProperties();
            entityWithoutProperties.SetValues(123456789, -987654321);

            DisplayDemoStep("Adding the entities to the database");

            context.EntitiesWithRichProperties.Add(newEntityWithRichProperties);
            context.EntitiesWithoutProperties.Add(entityWithoutProperties);
            context.SaveChanges();

            DisplayDemoStep("Loading the entities from the database");

            context = new PersistingAndConstructingEntitiesContext();

            var loadedEntityWithRichProperties = context.EntitiesWithRichProperties.First();
            var loadedEntityWithoutProperties = context.EntitiesWithoutProperties.First();

            DisplayDemoStep("Displaying the loaded entities");

            DisplayText($"Loaded entity with rich properties:{Environment.NewLine}" +
                              $"{nameof(EntityWithRichProperties.Id)} = {loadedEntityWithRichProperties.Id}{Environment.NewLine}" +
                              $"{nameof(EntityWithRichProperties.SomePropertyWithRichLogic)} = {loadedEntityWithRichProperties.SomePropertyWithRichLogic}{Environment.NewLine}" +
                              $"{nameof(EntityWithRichProperties.SomeOtherPropertyWithRichLogic)} = {loadedEntityWithRichProperties.SomeOtherPropertyWithRichLogic}{Environment.NewLine}");

            DisplayText($"Loaded entity without properties:{Environment.NewLine}" +
                              $"{nameof(EntityWithoutProperties.GetId)} = {loadedEntityWithoutProperties.GetId()}{Environment.NewLine}" +
                              $"{nameof(EntityWithoutProperties.GetSomeValue)} = {loadedEntityWithoutProperties.GetSomeValue()}{Environment.NewLine}" +
                              $"{nameof(EntityWithoutProperties.GetSomeOtherValue)} = {loadedEntityWithoutProperties.GetSomeOtherValue()}{Environment.NewLine}");
        }
    }
}
