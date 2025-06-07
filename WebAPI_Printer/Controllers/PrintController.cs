using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Printer.Models;
using WebAPI_Printer.Services;

namespace WebAPI_Printer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrintController : ControllerBase
    {
        private readonly IPrintService _printService;

        public PrintController(IPrintService printService)
        {
            _printService = printService;
        }

  
        [HttpGet("GetQuota/{userId}")]
        public async Task<ActionResult<PrintQuotaResultDto>> GetQuota(string userId)
        {
            try
            {
                var result = await _printService.GetQuota(userId);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
