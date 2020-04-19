namespace PersistingAndConstructingEntities
{
    public class EntityWithoutProperties
    {
        private int id = 0;
        private int someValue;
        private int someOtherValue;

        public int GetId() => id;

        public int GetSomeValue() => someValue;

        public int GetSomeOtherValue() => someOtherValue;

        public void SetValues(int someValue, int someOtherValue)
        {
            // Here comes some very serious logic.
            this.someValue = someValue;
            this.someOtherValue = someOtherValue;

            // Here again some more very serious logic.

            // Then we fire some events and similar.
        }
    }
}
