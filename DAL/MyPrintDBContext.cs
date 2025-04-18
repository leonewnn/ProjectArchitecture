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

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=MyPrintDb;Trusted_Connection=True;");
        }
    }
}
