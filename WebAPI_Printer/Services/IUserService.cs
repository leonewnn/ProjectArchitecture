using System.Threading.Tasks;
using WebAPI_Printer.Models;

namespace WebAPI_Printer.Services
{
    public interface IUserService
    {
 
        Task AddMoney(AddMoneyDto request);
    }
}
