using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Microsoft.EntityFrameworkCore;

using WebAPI_Printer.Extensions;
using WebAPI_Printer.Models;

namespace WebAPI_Printer.Services
{
    public class PrintService : IPrintService
    {
        private readonly MyPrintDBContext _context;

        public PrintService(MyPrintDBContext context)
        {
            _context = context;
        }

        public async Task<PrintQuotaResultDto> GetQuota(string userId)
        {
         
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
                throw new KeyNotFoundException($"Utilisateur '{userId}' introuvable.");

          
            var prices = await _context.PrintPrices.ToListAsync();

       
            return user.ToPrintQuotaResultDto(prices);
        }
    }
}
