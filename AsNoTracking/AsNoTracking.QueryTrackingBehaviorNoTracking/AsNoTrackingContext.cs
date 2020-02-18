using Microsoft.EntityFrameworkCore;

namespace AsNoTracking
{
    public class AsNoTrackingContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(
                    @"Server=(localdb)\mssqllocaldb;Database=EntityFrameworkCoreHiddenGems.AsNoTracking;Trusted_Connection=True;ConnectRetryCount=0;")

                // .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                ;
        }
    }
}
