using EntityFrameworkCoreHiddenGems;
using Microsoft.EntityFrameworkCore;

namespace AsNoTracking
{
    public class AsNoTrackingContext : BaseDemoDbContext
    {
        public DbSet<Author> Authors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
    }
}
