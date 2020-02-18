using System.Collections.Generic;
using System.Linq;

namespace AsNoTracking
{
    public class CustomersServiceWithTracking
    {
        private readonly AsNoTrackingContext context;

        public CustomersServiceWithTracking(AsNoTrackingContext context)
        {
            this.context = context;
        }

        public IReadOnlyCollection<Customer> GetCustomers()
        {
            return context.Customers.ToList();
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
