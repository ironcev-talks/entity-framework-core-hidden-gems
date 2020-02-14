using System;
using System.Linq;

namespace QueryTags
{
    public class Program
    {
        private static void Main()
        {
            var db = new QueryTagsContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            Console.Clear();

            //var executor = new WithoutQueryTags(db);
            var executor = new WithQueryTags(db);

            executor.ExecuteLotOfQueries();

            Console.ReadLine();
        }
    }
}
