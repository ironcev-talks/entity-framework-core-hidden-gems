using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueryTags
{
    public class WithQueryTags
    {
        private readonly QueryTagsContext context;

        public WithQueryTags(QueryTagsContext context)
        {
            this.context = context;
        }

        public void ExecuteLotOfQueries()
        {
            for (int i = 0; i < 10; i++)
            {
                context.Customers
                    .TagWith($"Some meaningful description of the query #{i + 1}")
                    .TagWith($"Some additional description of the query #{i + 1}")
                    .Where(customer => customer.FirstName == "Nermina" && customer.LastName == "Kirin")
                    .ToList();
            }
        }
    }
}
