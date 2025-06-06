using System.Threading.Tasks;
using WebAPI_Printer.Models;

namespace WebAPI_Printer.Services
{
    public interface IPrintService
    {
       
        Task<PrintQuotaResultDto> GetQuota(string userId);
    }
}
