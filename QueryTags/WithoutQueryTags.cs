using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueryTags
{
    public class WithoutQueryTags
    {
        private readonly QueryTagsContext context;

        public WithoutQueryTags(QueryTagsContext context)
        {
            this.context = context;
        }

        public void ExecuteLotOfQueries()
        {
            for (int i = 0; i < 10; i++)
            {
                context.Customers
                    .Where(customer => customer.FirstName == "Nermina" && customer.LastName == "Kirin")
                    .ToList();
            }
        }
    }
}
