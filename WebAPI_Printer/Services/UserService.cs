using System;
using System.Threading.Tasks;
using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using WebAPI_Printer.Models;

namespace WebAPI_Printer.Services
{
    public class UserService : IUserService
    {
        private readonly MyPrintDBContext _context;

        public UserService(MyPrintDBContext context)
        {
            _context = context;
        }

        public async Task AddMoney(AddMoneyDto request)
        {
            if (request.Amount <= 0)
                throw new ArgumentException("Le montant doit être supérieur à 0.");

            User user = null;

            // ⭐ CORRECTION: Améliorer la validation pour gérer les valeurs null/vides
            if (!string.IsNullOrWhiteSpace(request.CardId))
            {
                user = await _context.Users
                    .SingleOrDefaultAsync(u => u.CardId == request.CardId.Trim());
            }
            else if (!string.IsNullOrWhiteSpace(request.Username))
            {
                user = await _context.Users
                    .SingleOrDefaultAsync(u => u.Username == request.Username.Trim());
            }
            else
            {
                throw new ArgumentException("Il faut fournir soit CardId, soit Username.");
            }

            if (user == null)
                throw new KeyNotFoundException("Utilisateur introuvable.");

            user.QuotaChf += request.Amount;
            await _context.SaveChangesAsync();
        }
    }
}
