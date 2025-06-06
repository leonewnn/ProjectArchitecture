using MVC_Printer.Models;

namespace MVC_Printer.Services
{
    public interface IUserService
    {
        Task AddMoney(AddMoneyViewModel request);
    }
}