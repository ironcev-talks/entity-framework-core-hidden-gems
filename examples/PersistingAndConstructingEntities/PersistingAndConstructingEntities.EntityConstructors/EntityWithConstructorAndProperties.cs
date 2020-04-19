using System;

namespace PersistingAndConstructingEntities
{
    public class EntityWithConstructorAndProperties
    {
        public EntityWithConstructorAndProperties(int someProperty, string someOtherProperty)
        {
            Console.WriteLine($"{nameof(EntityWithConstructorAndProperties)} constructor called.");

            SomeProperty = someProperty;
            SomeOtherProperty = someOtherProperty;
        }

        public int Id { get; }

        public int SomeProperty { get; }

        public string SomeOtherProperty { get; }
    }
}
