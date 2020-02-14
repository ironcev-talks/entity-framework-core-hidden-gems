namespace BackingFieldsAndEntityConstructors
{
    public class SomeComplexEntity
    {
        private int someValue;
        
        public SomeComplexEntity(string firstProperty, int someValue)
        {
            FirstProperty = firstProperty;
            this.someValue = someValue;
        }

        public int Id { get; private set; }
        public string FirstProperty { get; }
        public double ThirdProperty { get; private set; }

        public void SetThirdProperty(double newValue)
        {
            // Some serious business before setting the property.
            ThirdProperty = newValue;
        }

        private int somePropertyWithLogicAndBackingField;
        public int SomePropertyWithLogicAndBackingField
        {
            get => somePropertyWithLogicAndBackingField;
            set
            {
                // Here come some very serious logic.
                if (somePropertyWithLogicAndBackingField != value)
                {
                    somePropertyWithLogicAndBackingField = value;
                }                
            }
        }

        public void DoSomethingWithSomeValue(int newValue)
        {
            someValue = newValue;
        }

        public int GetSomethingRelatedToSomeValue()
        {
            // Calculate something and return it.
            return someValue;
        }
    }
}
