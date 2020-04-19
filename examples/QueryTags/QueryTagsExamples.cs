using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace QueryTags
{
    public class QueryTagsExamples
    {
        private readonly QueryTagsContext context;

        public QueryTagsExamples(QueryTagsContext context)
        {
            this.context = context;
        }

        public void ExecuteLotOfQueries(string partOfFirstName, string partOfLastName)
        {
            for (int i = 0; i < 10; i++)
            {
                context.Customers
                    .Where(customer => customer.FirstName.Contains(partOfFirstName) || customer.LastName.Contains(partOfLastName))
                    .ToList();
            }
        }

        public void ExecuteLotOfQueriesWithQueryTags(string partOfFirstName, string partOfLastName)
        {
            for (int i = 0; i < 10; i++)
            {
                context.Customers
                    .TagWith($"Some meaningful description of the query #{i + 1}")
                    .TagWith($"Some additional description of the query #{i + 1}")
                    .Where(customer => customer.FirstName.Contains(partOfFirstName) || customer.LastName.Contains(partOfLastName))
                    .ToList();
            }
        }
    }
}
