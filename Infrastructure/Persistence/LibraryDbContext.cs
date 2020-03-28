using Microsoft.Extensions.Logging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence.EntityConfiguration;

namespace Infrastructure.Persistence
{
    public class LibraryDbContext : DbContext
    {
        private readonly ILoggerFactory _loggerFactory;

        public LibraryDbContext(
            DbContextOptions<LibraryDbContext> options,
            ILoggerFactory loggerFactory)
            : base(options)
        {
            _loggerFactory = loggerFactory;
        }

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Authorization> Authorizations { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(_loggerFactory);
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new InvoiceEntityTypeConfiguration());

        }
    }
}
