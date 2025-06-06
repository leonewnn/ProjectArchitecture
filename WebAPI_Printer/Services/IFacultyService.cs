using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI_Printer.Models;

namespace WebAPI_Printer.Services
{
    public interface IFacultyService
    {
     
        Task<List<UserBalanceDto>> GetUsersByFaculty(int facultyId);

        Task<List<FacultyDto>> GetFaculties();
    }
}
