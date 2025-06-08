using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Printer.Models;
using WebAPI_Printer.Services;

namespace WebAPI_Printer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

 
        [HttpPost("AddMoney")]
        public async Task<IActionResult> AddMoney([FromBody] AddMoneyDto request)
        {
            try
            {
                await _userService.AddMoney(request);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
