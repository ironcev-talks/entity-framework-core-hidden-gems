using EntityFrameworkCoreHiddenGems;
using Microsoft.EntityFrameworkCore;

namespace PersistingAndConstructingEntities
{
    public class PersistingAndConstructingEntitiesContext : BaseDemoDbContext
    {
        public DbSet<EntityWithRichProperties> EntitiesWithRichProperties { get; set; }

        public DbSet<EntityWithoutProperties> EntitiesWithoutProperties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EntityWithRichProperties>(builder =>
            {
                builder.Property(x => x.SomePropertyWithRichLogic).HasField("somePropertyWithRichLogic");
                builder.Property(x => x.SomeOtherPropertyWithRichLogic).HasField("someOtherPropertyWithRichLogic");
            });

            modelBuilder.Entity<EntityWithoutProperties>(builder =>
            {
                builder.Property("id").HasColumnName("Id");
                builder.Property("someValue").HasColumnName("SomeValue");
                builder.Property("someOtherValue").HasColumnName("SomeOtherValue");
            });
        }
    }
}
