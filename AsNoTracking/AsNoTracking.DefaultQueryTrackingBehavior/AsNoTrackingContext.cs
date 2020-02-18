using Microsoft.EntityFrameworkCore;

namespace AsNoTracking
{
    public class AsNoTrackingContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EntityFrameworkCoreHiddenGems.AsNoTracking.DefaultQueryTrackingBehavior;Trusted_Connection=True;ConnectRetryCount=0");
        }
    }
}
