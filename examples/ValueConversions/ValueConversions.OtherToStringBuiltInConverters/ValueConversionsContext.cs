using EntityFrameworkCoreHiddenGems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ValueConversions
{
    public class ValueConversionsContext : BaseDemoDbContext
    {
        public DbSet<SomeEntity> SomeEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SomeEntity>()
                .Property(x => x.SomeDateTime)
                .HasConversion(new DateTimeToStringConverter());

            modelBuilder.Entity<SomeEntity>()
                .Property(x => x.SomeGuid)
                .HasConversion(new GuidToStringConverter());

            modelBuilder.Entity<SomeEntity>()
                .Property(x => x.SomeInt)
                .HasConversion(new NumberToStringConverter<int>());

            modelBuilder.Entity<SomeEntity>()
                .Property(x => x.SomeDouble)
                .HasConversion(new NumberToStringConverter<double>());

            modelBuilder.Entity<SomeEntity>()
                .Property(x => x.SomeEnum)
                .HasConversion(new EnumToStringConverter<SomeEnum>());

            modelBuilder.Entity<SomeEntity>()
                .Property(x => x.SomeFlagsEnum)
                .HasConversion(new EnumToStringConverter<SomeFlagsEnum>());
        }
    }
}
