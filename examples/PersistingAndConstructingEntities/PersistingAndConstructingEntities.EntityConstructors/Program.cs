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

            var newEntityWithConstructorAndProperties = new EntityWithConstructorAndProperties(123456789, "-987654321");

            var newEntityWithConstructorAndFields = new EntityWithConstructorAndFields(123456789, "-987654321");

            DisplayDemoStep("Adding the entities to the database");

            context.EntitiesWithConstructorAndProperties.Add(newEntityWithConstructorAndProperties);
            context.EntitiesWithConstructorAndFields.Add(newEntityWithConstructorAndFields);
            context.SaveChanges();

            DisplayDemoStep("Loading the entities from the database");

            context = new PersistingAndConstructingEntitiesContext();

            var loadedEntityWithConstructorAndProperties = context.EntitiesWithConstructorAndProperties.First();
            var loadedEntityWithConstructorAndFields = context.EntitiesWithConstructorAndFields.First();

            DisplayDemoStep("Displaying the loaded entities");

            Console.WriteLine($"Loaded entity with constructor and properties:{Environment.NewLine}" +
                              $"{nameof(EntityWithConstructorAndProperties.Id)} = {loadedEntityWithConstructorAndProperties.Id}{Environment.NewLine}" +
                              $"{nameof(EntityWithConstructorAndProperties.SomeProperty)} = {loadedEntityWithConstructorAndProperties.SomeProperty}{Environment.NewLine}" +
                              $"{nameof(EntityWithConstructorAndProperties.SomeOtherProperty)} = {loadedEntityWithConstructorAndProperties.SomeOtherProperty}{Environment.NewLine}");

            Console.WriteLine($"Loaded entity constructor and fields:{Environment.NewLine}" +
                              $"{nameof(EntityWithConstructorAndFields.Id)} = {loadedEntityWithConstructorAndFields.Id}{Environment.NewLine}" +
                              $"{nameof(EntityWithConstructorAndFields.GetSomeValue)} = {loadedEntityWithConstructorAndFields.GetSomeValue()}{Environment.NewLine}" +
                              $"{nameof(EntityWithConstructorAndFields.GetSomeOtherValue)} = {loadedEntityWithConstructorAndFields.GetSomeOtherValue()}{Environment.NewLine}");
        }
    }
}
