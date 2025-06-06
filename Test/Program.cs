using DAL;
using Microsoft.EntityFrameworkCore;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new MyPrintDBContext();
            
            // Ceci va déclencher le seeding automatiquement
            context.Database.EnsureCreated();
            
            Console.WriteLine("Database created and seeded!");
            Console.WriteLine("Faculties: " + context.Faculties.Count());
            Console.WriteLine("Users: " + context.Users.Count());
            Console.WriteLine("PrintPrices: " + context.PrintPrices.Count());
            
            Console.WriteLine("Done!");
            Console.WriteLine("Startup project for EF Core migrations.");
        }
    }
}