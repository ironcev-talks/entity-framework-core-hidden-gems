using System.Collections.Generic;
using System.Linq;

namespace AsNoTracking
{
    public class AuthorService
    {
        private readonly AsNoTrackingContext context;

        public AuthorService(AsNoTrackingContext context)
        {
            this.context = context;
        }

        public IReadOnlyCollection<Author> GetAuthors()
        {
            return context.Authors.ToList();
        }

        public void DoSomethingWithAuthors()
        {
            var customers = context.Authors.ToList();
            foreach (var customer in customers)
            {
                customer.FirstName += "...";
            }

            context.SaveChanges();
        }
    }
}
