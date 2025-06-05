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

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=MyPrintDb;Trusted_Connection=True;");
            }

            // Seeding synchrone
            builder.UseSeeding((context, _) =>
            {
                // Faculties
                var faculty1 = new Faculty() { Name = "Computer Science" };
                var faculty = context.Set<Faculty>().FirstOrDefault(f => f.FacultyId == 1);
                if (faculty == null)
                {
                    context.Set<Faculty>().Add(faculty1);
                    context.SaveChanges();
                }

                var faculty2 = new Faculty() { Name = "Economics and Management" };
                faculty = context.Set<Faculty>().FirstOrDefault(f => f.FacultyId == 2);
                if (faculty == null)
                {
                    context.Set<Faculty>().Add(faculty2);
                    context.SaveChanges();
                }

                var faculty3 = new Faculty() { Name = "Law" };
                faculty = context.Set<Faculty>().FirstOrDefault(f => f.FacultyId == 3);
                if (faculty == null)
                {
                    context.Set<Faculty>().Add(faculty3);
                    context.SaveChanges();
                }

                var faculty4 = new Faculty() { Name = "Medicine" };
                faculty = context.Set<Faculty>().FirstOrDefault(f => f.FacultyId == 4);
                if (faculty == null)
                {
                    context.Set<Faculty>().Add(faculty4);
                    context.SaveChanges();
                }

                // PrintPrices
                var printPrice1 = new PrintPrice() { TypeCode = "A4_BW", PricePerPage = 0.08m };
                var printPrice = context.Set<PrintPrice>().FirstOrDefault(p => p.TypeCode == "A4_BW");
                if (printPrice == null)
                {
                    context.Set<PrintPrice>().Add(printPrice1);
                    context.SaveChanges();
                }

                var printPrice2 = new PrintPrice() { TypeCode = "A4_COLOR", PricePerPage = 0.15m };
                printPrice = context.Set<PrintPrice>().FirstOrDefault(p => p.TypeCode == "A4_COLOR");
                if (printPrice == null)
                {
                    context.Set<PrintPrice>().Add(printPrice2);
                    context.SaveChanges();
                }

                var printPrice3 = new PrintPrice() { TypeCode = "A3_BW", PricePerPage = 0.10m };
                printPrice = context.Set<PrintPrice>().FirstOrDefault(p => p.TypeCode == "A3_BW");
                if (printPrice == null)
                {
                    context.Set<PrintPrice>().Add(printPrice3);
                    context.SaveChanges();
                }

                var printPrice4 = new PrintPrice() { TypeCode = "A3_COLOR", PricePerPage = 0.30m };
                printPrice = context.Set<PrintPrice>().FirstOrDefault(p => p.TypeCode == "A3_COLOR");
                if (printPrice == null)
                {
                    context.Set<PrintPrice>().Add(printPrice4);
                    context.SaveChanges();
                }

                // Users
                var user1 = new User() 
                { 
                    Uid = "user001", 
                    Username = "alice.martin", 
                    CardId = "CARD001", 
                    FacultyId = 1, 
                    QuotaChf = 25.00m 
                };
                var user = context.Set<User>().FirstOrDefault(u => u.Uid == "user001");
                if (user == null)
                {
                    context.Set<User>().Add(user1);
                    context.SaveChanges();
                }

                var user2 = new User() 
                { 
                    Uid = "user002", 
                    Username = "bob.smith", 
                    CardId = "CARD002", 
                    FacultyId = 2, 
                    QuotaChf = 15.50m 
                };
                user = context.Set<User>().FirstOrDefault(u => u.Uid == "user002");
                if (user == null)
                {
                    context.Set<User>().Add(user2);
                    context.SaveChanges();
                }

                var user3 = new User() 
                { 
                    Uid = "user003", 
                    Username = "claire.johnson", 
                    CardId = "CARD003", 
                    FacultyId = 1, 
                    QuotaChf = 30.00m 
                };
                user = context.Set<User>().FirstOrDefault(u => u.Uid == "user003");
                if (user == null)
                {
                    context.Set<User>().Add(user3);
                    context.SaveChanges();
                }

                var user4 = new User() 
                { 
                    Uid = "user004", 
                    Username = "david.brown", 
                    CardId = "CARD004", 
                    FacultyId = 3, 
                    QuotaChf = 12.75m 
                };
                user = context.Set<User>().FirstOrDefault(u => u.Uid == "user004");
                if (user == null)
                {
                    context.Set<User>().Add(user4);
                    context.SaveChanges();
                }

                var user5 = new User() 
                { 
                    Uid = "user005", 
                    Username = "emma.wilson", 
                    CardId = "CARD005", 
                    FacultyId = 4, 
                    QuotaChf = 18.25m 
                };
                user = context.Set<User>().FirstOrDefault(u => u.Uid == "user005");
                if (user == null)
                {
                    context.Set<User>().Add(user5);
                    context.SaveChanges();
                }

                var user6 = new User() 
                { 
                    Uid = "user006", 
                    Username = "felix.anderson", 
                    CardId = "CARD006", 
                    FacultyId = 2, 
                    QuotaChf = 22.50m 
                };
                user = context.Set<User>().FirstOrDefault(u => u.Uid == "user006");
                if (user == null)
                {
                    context.Set<User>().Add(user6);
                    context.SaveChanges();
                }
            })
            // Seeding asynchrone
            .UseAsyncSeeding(async (context, _, cancellationToken) =>
            {
                // Faculties
                var faculty1 = new Faculty() { FacultyId = 1, Name = "Computer Science" };
                var faculty = await context.Set<Faculty>().FirstOrDefaultAsync(f => f.FacultyId == 1, cancellationToken);
                if (faculty == null)
                {
                    context.Set<Faculty>().Add(faculty1);
                    await context.SaveChangesAsync(cancellationToken);
                }

                var faculty2 = new Faculty() { FacultyId = 2, Name = "Economics and Management" };
                faculty = await context.Set<Faculty>().FirstOrDefaultAsync(f => f.FacultyId == 2, cancellationToken);
                if (faculty == null)
                {
                    context.Set<Faculty>().Add(faculty2);
                    await context.SaveChangesAsync(cancellationToken);
                }

                var faculty3 = new Faculty() { FacultyId = 3, Name = "Law" };
                faculty = await context.Set<Faculty>().FirstOrDefaultAsync(f => f.FacultyId == 3, cancellationToken);
                if (faculty == null)
                {
                    context.Set<Faculty>().Add(faculty3);
                    await context.SaveChangesAsync(cancellationToken);
                }

                var faculty4 = new Faculty() { FacultyId = 4, Name = "Medicine" };
                faculty = await context.Set<Faculty>().FirstOrDefaultAsync(f => f.FacultyId == 4, cancellationToken);
                if (faculty == null)
                {
                    context.Set<Faculty>().Add(faculty4);
                    await context.SaveChangesAsync(cancellationToken);
                }

                // PrintPrices
                var printPrice1 = new PrintPrice() { TypeCode = "A4_BW", PricePerPage = 0.05m };
                var printPrice = await context.Set<PrintPrice>().FirstOrDefaultAsync(p => p.TypeCode == "A4_BW", cancellationToken);
                if (printPrice == null)
                {
                    context.Set<PrintPrice>().Add(printPrice1);
                    await context.SaveChangesAsync(cancellationToken);
                }

                var printPrice2 = new PrintPrice() { TypeCode = "A4_COLOR", PricePerPage = 0.15m };
                printPrice = await context.Set<PrintPrice>().FirstOrDefaultAsync(p => p.TypeCode == "A4_COLOR", cancellationToken);
                if (printPrice == null)
                {
                    context.Set<PrintPrice>().Add(printPrice2);
                    await context.SaveChangesAsync(cancellationToken);
                }

                var printPrice3 = new PrintPrice() { TypeCode = "A3_BW", PricePerPage = 0.10m };
                printPrice = await context.Set<PrintPrice>().FirstOrDefaultAsync(p => p.TypeCode == "A3_BW", cancellationToken);
                if (printPrice == null)
                {
                    context.Set<PrintPrice>().Add(printPrice3);
                    await context.SaveChangesAsync(cancellationToken);
                }

                var printPrice4 = new PrintPrice() { TypeCode = "A3_COLOR", PricePerPage = 0.30m };
                printPrice = await context.Set<PrintPrice>().FirstOrDefaultAsync(p => p.TypeCode == "A3_COLOR", cancellationToken);
                if (printPrice == null)
                {
                    context.Set<PrintPrice>().Add(printPrice4);
                    await context.SaveChangesAsync(cancellationToken);
                }

                // Users
                var user1 = new User() 
                { 
                    Uid = "user001", 
                    Username = "alice.martin", 
                    CardId = "CARD001", 
                    FacultyId = 1, 
                    QuotaChf = 25.00m 
                };
                var user = await context.Set<User>().FirstOrDefaultAsync(u => u.Uid == "user001", cancellationToken);
                if (user == null)
                {
                    context.Set<User>().Add(user1);
                    await context.SaveChangesAsync(cancellationToken);
                }

                var user2 = new User() 
                { 
                    Uid = "user002", 
                    Username = "bob.smith", 
                    CardId = "CARD002", 
                    FacultyId = 2, 
                    QuotaChf = 15.50m 
                };
                user = await context.Set<User>().FirstOrDefaultAsync(u => u.Uid == "user002", cancellationToken);
                if (user == null)
                {
                    context.Set<User>().Add(user2);
                    await context.SaveChangesAsync(cancellationToken);
                }

                var user3 = new User() 
                { 
                    Uid = "user003", 
                    Username = "claire.johnson", 
                    CardId = "CARD003", 
                    FacultyId = 1, 
                    QuotaChf = 30.00m 
                };
                user = await context.Set<User>().FirstOrDefaultAsync(u => u.Uid == "user003", cancellationToken);
                if (user == null)
                {
                    context.Set<User>().Add(user3);
                    await context.SaveChangesAsync(cancellationToken);
                }

                var user4 = new User() 
                { 
                    Uid = "user004", 
                    Username = "david.brown", 
                    CardId = "CARD004", 
                    FacultyId = 3, 
                    QuotaChf = 12.75m 
                };
                user = await context.Set<User>().FirstOrDefaultAsync(u => u.Uid == "user004", cancellationToken);
                if (user == null)
                {
                    context.Set<User>().Add(user4);
                    await context.SaveChangesAsync(cancellationToken);
                }

                var user5 = new User() 
                { 
                    Uid = "user005", 
                    Username = "emma.wilson", 
                    CardId = "CARD005", 
                    FacultyId = 4, 
                    QuotaChf = 18.25m 
                };
                user = await context.Set<User>().FirstOrDefaultAsync(u => u.Uid == "user005", cancellationToken);
                if (user == null)
                {
                    context.Set<User>().Add(user5);
                    await context.SaveChangesAsync(cancellationToken);
                }

                var user6 = new User() 
                { 
                    Uid = "user006", 
                    Username = "felix.anderson", 
                    CardId = "CARD006", 
                    FacultyId = 2, 
                    QuotaChf = 22.50m 
                };
                user = await context.Set<User>().FirstOrDefaultAsync(u => u.Uid == "user006", cancellationToken);
                if (user == null)
                {
                    context.Set<User>().Add(user6);
                    await context.SaveChangesAsync(cancellationToken);
                }
            });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure User entity - Seulement ce qui n'est PAS dans les attributs
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
