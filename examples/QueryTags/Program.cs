using QueryTags;
using System;

namespace EntityFrameworkCoreHiddenGems
{
    public partial class Program
    {
        private static void Main()
        {
            var context = new QueryTagsContext();
            CreateDatabase(context);

            Console.Clear();

            var examples = new QueryTagsExamples(context);

            DisplayDemoStep("Execute lot of queries");

            examples.ExecuteLotOfQueries("go", "on");

            Console.ReadLine();

            DisplayDemoStep("Execute lot of queries with query tags");

            examples.ExecuteLotOfQueriesWithQueryTags("go", "on");
        }
    }
}
