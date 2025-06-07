using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Printer.Models;
using WebAPI_Printer.Services;

namespace WebAPI_Printer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacultyController : ControllerBase
    {
        private readonly IFacultyService _facultyService;

        public FacultyController(IFacultyService facultyService)
        {
            _facultyService = facultyService;
        }

        
        [HttpGet("GetUsersByFaculty/{facultyId}")]
        public async Task<ActionResult<List<UserBalanceDto>>> GetUsersByFaculty(int facultyId)
        {
            var users = await _facultyService.GetUsersByFaculty(facultyId);
            return Ok(users);
        }

        
        [HttpGet("GetFaculties")]
        public async Task<ActionResult<List<FacultyDto>>> GetFaculties()
        {
            var faculties = await _facultyService.GetFaculties();
            return Ok(faculties);
        }
    }
}
