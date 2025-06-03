using Microsoft.EntityFrameworkCore;
using ProjectArchitecture.Models;

namespace DAL
{
    public class MyPrintCBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<PrintJob> PrintJobs { get; set; }
        public DbSet<PrintType> PrintTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=MyPrintDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seule configuration nécessaire : PrintType avec TypeCode comme PK
            modelBuilder.Entity<PrintType>()
                .HasKey(pt => pt.TypeCode);
            base.OnModelCreating(modelBuilder);
        }
    }
}
