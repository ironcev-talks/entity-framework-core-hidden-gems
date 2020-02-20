using System;

namespace PersistingAndConstructingEntities
{
    public class EntityWithConstructorAndFields
    {
        private readonly int someValue;
        private readonly string someOtherValue;

        public EntityWithConstructorAndFields(int someValue, string someOtherValue)
        {
            Console.WriteLine($"{nameof(EntityWithConstructorAndFields)} constructor called.");

            this.someValue = someValue;
            this.someOtherValue = someOtherValue;
        }

        public int Id { get; }

        public int FirstProperty { get; set; }

        public string SecondProperty { get; set; }

        public int GetSomeValue() => someValue;

        public string GetSomeOtherValue() => someOtherValue;
    }
}
