using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AsNoTracking
{
    public class CustomersServiceWithExplicitNoTracking
    {
        private readonly AsNoTrackingContext context;

        public CustomersServiceWithExplicitNoTracking(AsNoTrackingContext context)
        {
            this.context = context;
        }

        public IReadOnlyCollection<Customer> GetCustomers()
        {
            return context.Customers.AsNoTracking().ToList();
        }

        public void DoSomethingWithCustomers()
        {
            var customers = context.Customers.ToList();
            foreach (var customer in customers)
            {
                customer.FirstName += "...";
            }

            context.SaveChanges();
        }
    }
}
