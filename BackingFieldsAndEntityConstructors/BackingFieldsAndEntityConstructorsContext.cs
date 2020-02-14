using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BackingFieldsAndEntityConstructors
{
    public class BackingFieldsAndEntityConstructorsContext : DbContext
    {
        private static readonly ILoggerFactory LoggerFactory
            = Microsoft.Extensions.Logging.LoggerFactory
                .Create(builder =>
                    builder
                        .AddConsole()
                        .AddFilter((s, l) => l == LogLevel.Information && !s.EndsWith("Connection"))
                );

        public DbSet<SomeComplexEntity> SomeComplexEntities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(
                    @"Server=(localdb)\mssqllocaldb;Database=EntityFrameworkCoreHiddenGems.BackingFieldsAndEntityConstructors;Trusted_Connection=True;ConnectRetryCount=0;")
                .UseLoggerFactory(LoggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SomeComplexEntity>()
                .Property(x => x.FirstProperty);

            modelBuilder.Entity<SomeComplexEntity>()
                .Property("someValue")
                .HasColumnName("SomeValue");

            modelBuilder.Entity<SomeComplexEntity>()
                .Property(x => x.SomePropertyWithLogicAndBackingField)
                .HasField("somePropertyWithLogicAndBackingField")
                .UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
