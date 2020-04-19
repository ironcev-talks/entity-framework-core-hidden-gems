using EntityFrameworkCoreHiddenGems;
using Microsoft.EntityFrameworkCore;

namespace AsNoTracking
{
    public class AsNoTrackingContext : BaseDemoDbContext
    {
        public DbSet<Author> Authors { get; set; }
    }
}
