using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using WebAPI_Printer.Services;

namespace WebAPI_Printer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            // Configure DbContext
            builder.Services.AddDbContext<MyPrintDBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // ✅ AJOUTER : Enregistrement des services
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IPrintService, PrintService>();
            builder.Services.AddScoped<IFacultyService, FacultyService>();

            var app = builder.Build();

            // Seeding de la base de données
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<MyPrintDBContext>();
                context.Database.Migrate(); // DÉCOMMENTER pour Azure - crée les tables
                SeedDatabase(context);
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }

        static void SeedDatabase(MyPrintDBContext context)
        {
            // Seed Faculties
            var facultiesToAdd = new List<Faculty>
            {
                new Faculty { Name = "Computer Science" },
                new Faculty { Name = "Economics and Management" },
                new Faculty { Name = "Law" },
                new Faculty { Name = "Medicine" }
            };

            foreach (var faculty in facultiesToAdd)
            {
                if (!context.Faculties.Any(f => f.Name == faculty.Name))
                {
                    context.Faculties.Add(faculty);
                }
            }
            context.SaveChanges();

            // Seed PrintPrices
            var printPricesToAdd = new List<PrintPrice>
            {
                new PrintPrice { TypeCode = "A4_BW", PricePerPage = 0.08m },
                new PrintPrice { TypeCode = "A4_COLOR", PricePerPage = 0.15m },
                new PrintPrice { TypeCode = "A3_BW", PricePerPage = 0.10m },
                new PrintPrice { TypeCode = "A3_COLOR", PricePerPage = 0.30m }
            };

            foreach (var printPrice in printPricesToAdd)
            {
                if (!context.PrintPrices.Any(p => p.TypeCode == printPrice.TypeCode))
                {
                    context.PrintPrices.Add(printPrice);
                }
            }
            context.SaveChanges();

            // Seed Users
            var usersToAdd = new List<User>
            {
                new User { Uid = "user001", Username = "alice.martin", CardId = "CARD001", FacultyId = 1, QuotaChf = 25.00m },
                new User { Uid = "user002", Username = "bob.smith", CardId = "CARD002", FacultyId = 2, QuotaChf = 15.50m },
                new User { Uid = "user003", Username = "claire.johnson", CardId = "CARD003", FacultyId = 1, QuotaChf = 30.00m },
                new User { Uid = "user004", Username = "david.brown", CardId = "CARD004", FacultyId = 3, QuotaChf = 12.75m },
                new User { Uid = "user005", Username = "emma.wilson", CardId = "CARD005", FacultyId = 4, QuotaChf = 18.25m },
                new User { Uid = "user006", Username = "felix.anderson", CardId = "CARD006", FacultyId = 2, QuotaChf = 22.50m }
            };

            foreach (var user in usersToAdd)
            {
                if (!context.Users.Any(u => u.Username == user.Username))
                {
                    context.Users.Add(user);
                }
            }
            context.SaveChanges();
        }
    }
}
