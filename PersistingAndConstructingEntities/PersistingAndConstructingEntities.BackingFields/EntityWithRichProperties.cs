using System;

namespace PersistingAndConstructingEntities
{
    public class EntityWithRichProperties
    {
        public int Id { get; private set; }

        private int somePropertyWithRichLogic;

        public int SomePropertyWithRichLogic
        {
            get
            {
                Console.WriteLine($"{nameof(EntityWithRichProperties)}.{nameof(SomePropertyWithRichLogic)} getter called.");

                return somePropertyWithRichLogic;
            }

            set
            {
                Console.WriteLine($"{nameof(EntityWithRichProperties)}.{nameof(SomePropertyWithRichLogic)} setter called.");

                // Here comes some very serious logic.

                if (somePropertyWithRichLogic != value)
                {
                    // Here again some more very serious logic.
                    somePropertyWithRichLogic = value;

                    // Then we fire some events and similar.
                }
            }
        }

        private int someOtherPropertyWithRichLogic;

        public int SomeOtherPropertyWithRichLogic
        {
            get
            {
                Console.WriteLine($"{nameof(EntityWithRichProperties)}.{nameof(SomeOtherPropertyWithRichLogic)} getter called.");

                return someOtherPropertyWithRichLogic;
            }

            set
            {
                Console.WriteLine($"{nameof(EntityWithRichProperties)}.{nameof(SomeOtherPropertyWithRichLogic)} setter called.");

                // Here comes some very serious logic.

                if (someOtherPropertyWithRichLogic != value)
                {
                    // Here again some more very serious logic.
                    someOtherPropertyWithRichLogic = value;

                    // Then we fire some events and similar.
                }
            }
        }
    }
}
