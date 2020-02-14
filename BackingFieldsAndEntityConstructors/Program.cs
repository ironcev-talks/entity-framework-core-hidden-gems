using System;
using System.Linq;

namespace BackingFieldsAndEntityConstructors
{
    public class Program
    {
        private static void Main()
        {
            var db = new BackingFieldsAndEntityConstructorsContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            Console.Clear();

            var newEntity = new SomeComplexEntity("FirstProperty", 123);
            newEntity.SetThirdProperty(456.789);
            newEntity.SomePropertyWithLogicAndBackingField = 10_000;
            newEntity.DoSomethingWithSomeValue(321);

            db.SomeComplexEntities.Add(newEntity);
            db.SaveChanges();


            db = new BackingFieldsAndEntityConstructorsContext();
            var savedEntity = db.SomeComplexEntities.First();

            Console.WriteLine(savedEntity.FirstProperty);
            Console.WriteLine(savedEntity.ThirdProperty);
            Console.WriteLine(savedEntity.SomePropertyWithLogicAndBackingField);
            Console.WriteLine(savedEntity.GetSomethingRelatedToSomeValue());
        }
    }
}
