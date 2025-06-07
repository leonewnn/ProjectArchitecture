using Microsoft.EntityFrameworkCore;
using DAL.Models;

namespace DAL
{
    public class MyPrintDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<PrintPrice> PrintPrices { get; set; }

        public MyPrintDBContext() { }

        public MyPrintDBContext(DbContextOptions<MyPrintDBContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure User entity
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.CardId).IsUnique(); 
                entity.HasOne(e => e.Faculty)
                      .WithMany(f => f.Users)
                      .HasForeignKey(e => e.FacultyId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
