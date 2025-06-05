using MVC_Printer.Models;

namespace MVC_Printer.Services
{
    public interface IPrintService
    {
        Task<PrintQuotaViewModel> GetQuota(string userId);
    }
}