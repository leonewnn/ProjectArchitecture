using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Microsoft.EntityFrameworkCore;

using WebAPI_Printer.Extensions;
using WebAPI_Printer.Models;

namespace WebAPI_Printer.Services
{
    public class FacultyService : IFacultyService
    {
        private readonly MyPrintDBContext _context;

        public FacultyService(MyPrintDBContext context)
        {
            _context = context;
        }

        public async Task<List<UserBalanceDto>> GetUsersByFaculty(int facultyId)
        {
            // 1. Charger tous les utilisateurs de la faculté
            var users = await _context.Users
                .Where(u => u.FacultyId == facultyId)
                .ToListAsync();

            // 2. Convertir en UserBalanceDto
            return users
                .Select(u => u.ToUserBalanceDto())
                .ToList();
        }

        public async Task<List<FacultyDto>> GetFaculties()
        {
            var faculties = await _context.Faculties.ToListAsync();
            return faculties
                .Select(f => f.ToFacultyDto())
                .ToList();
        }
    }
}
