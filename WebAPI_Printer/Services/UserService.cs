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

            if (!string.IsNullOrEmpty(request.CardId))
            {
                user = await _context.Users
                    .SingleOrDefaultAsync(u => u.CardId == request.CardId);
            }
            else if (!string.IsNullOrEmpty(request.Username))
            {
                user = await _context.Users
                    .SingleOrDefaultAsync(u => u.Username == request.Username);
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
