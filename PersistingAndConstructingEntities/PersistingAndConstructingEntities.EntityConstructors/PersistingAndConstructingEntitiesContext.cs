using EntityFrameworkCoreHiddenGems;
using Microsoft.EntityFrameworkCore;

namespace PersistingAndConstructingEntities
{
    public class PersistingAndConstructingEntitiesContext : BaseDemoDbContext
    {
        public DbSet<EntityWithConstructorAndProperties> EntitiesWithConstructorAndProperties { get; set; }

        public DbSet<EntityWithConstructorAndFields> EntitiesWithConstructorAndFields { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EntityWithConstructorAndProperties>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.SomeProperty);
                builder.Property(x => x.SomeOtherProperty);
            });

            modelBuilder.Entity<EntityWithConstructorAndFields>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.Property("someValue").HasColumnName("SomeValue");
                builder.Property("someOtherValue").HasColumnName("SomeOtherValue");
            });
        }
    }
}
