using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AsNoTracking
{
    public class CustomersServiceWithDefaultQueryTrackingBehaviorNoTracking
    {
        private readonly AsNoTrackingContext context;

        public CustomersServiceWithDefaultQueryTrackingBehaviorNoTracking(AsNoTrackingContext context)
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

        public void DoSomethingWithCustomers01()
        {
            var customers = context.Customers.AsTracking().ToList();
            foreach (var customer in customers)
            {
                customer.FirstName += "...";
            }

            context.SaveChanges();
        }
    }
}
