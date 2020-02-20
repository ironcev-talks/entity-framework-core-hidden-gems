using EntityFrameworkCoreHiddenGems;
using Microsoft.EntityFrameworkCore;

namespace QueryTags
{
    public class QueryTagsContext : BaseDemoDbContext
    {
        public DbSet<Customer> Customers { get; set; }
    }
}
