using MVC_Printer.Models;

namespace MVC_Printer.Services
{
    public interface IFacultyService
    {
        Task<List<FacultyViewModel>> GetFaculties();
        Task<List<UserBalanceViewModel>> GetUsersByFaculty(int facultyId);
    }
}