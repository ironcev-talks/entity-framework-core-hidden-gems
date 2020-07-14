using System;

namespace ValueConversions
{
    public class SomeEntity
    {
        public int Id { get; set; }

        public DateTime SomeDateTime { get; set; }

        public Guid SomeGuid { get; set; }

        public int SomeInt { get; set; }

        public double SomeDouble { get; set; }

        public SomeEnum SomeEnum { get; set; }

        public SomeFlagsEnum SomeFlagsEnum { get; set; }
    }

    public enum SomeEnum
    {
        First,
        Second,
        Third
    }

    [Flags]
    public enum SomeFlagsEnum
    {
        First = 1,
        Second = 2,
        Third = 4
    }
}
