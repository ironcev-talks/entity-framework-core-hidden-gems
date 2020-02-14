using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Logging;

namespace ValueConversions
{
    public class ValueConversionsContext : DbContext
    {
        private static readonly ILoggerFactory LoggerFactory
            = Microsoft.Extensions.Logging.LoggerFactory
                .Create(builder =>
                    builder
                        .AddConsole()
                        .AddFilter((s, l) => l == LogLevel.Information && !s.EndsWith("Connection"))
                );

        public DbSet<BeTrue> BeTrues { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(
                    @"Server=(localdb)\mssqllocaldb;Database=EntityFrameworkCoreHiddenGems.ValueConversions;Trusted_Connection=True;ConnectRetryCount=0;")
                .UseLoggerFactory(LoggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BeTrue>()
                .Property(x => x.DaNe)
                .HasConversion(new BoolToStringConverter("Ne", "Da"));

            modelBuilder.Entity<BeTrue>()
                .Property(x => x.Dn)
                .HasConversion(new BoolToStringConverter("N", "D"));

            modelBuilder.Entity<BeTrue>()
                .Property(x => x.JaNein)
                .HasConversion(new BoolToStringConverter("Nein", "Ja"));

            modelBuilder.Entity<BeTrue>()
                .Property(x => x.Jn)
                .HasConversion(new BoolToStringConverter("N", "J"));

            modelBuilder.Entity<BeTrue>()
                .Property(x => x.YesNo)
                .HasConversion(new BoolToStringConverter("No", "Yes"));

            modelBuilder.Entity<BeTrue>()
                .Property(x => x.Yn)
                .HasConversion(new BoolToStringConverter("N", "Y"));

            modelBuilder.Entity<BeTrue>()
                .Property(x => x.ZeroOne)
                .HasConversion(new BoolToZeroOneConverter<int>());

            modelBuilder.Entity<BeTrue>()
                .Property(x => x.OneMinusOne)
                .HasConversion(new BoolToTwoValuesConverter<int>(-1, 1));

            modelBuilder.Entity<BeTrue>()
                .Property(x => x.MyOwnTruth)
                .HasConversion
                (
                    x => "let it be " + x.ToString().ToLowerInvariant(),
                    x => Convert.ToBoolean(x.Replace("let it be ", string.Empty))
                );
        }
    }
}
