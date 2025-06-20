// filepath: MVC_Printer/Controllers/PrinterController.cs
using Microsoft.AspNetCore.Mvc;
using MVC_Printer.Models;
using MVC_Printer.Services;
using System.Diagnostics;

namespace MVC_Printer.Controllers
{
    public class PrinterController : Controller
    {
        private readonly IUserService _userService;
        private readonly IPrintService _printService;
        private readonly IFacultyService _facultyService;

        public PrinterController(IPrintService printService, IUserService userService, IFacultyService facultyService)
        {
            _printService = printService;
            _userService = userService;
            _facultyService = facultyService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetQuota(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                TempData["Error"] = "Please enter a User ID";
                return RedirectToAction("Index");
            }

           
                var quota = await _printService.GetQuota(userId);
                return View("QuotaResult", quota);
            
         
        }

        [HttpGet]
        public IActionResult AddMoney()
        {
            return View(new AddMoneyViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> AddMoney(AddMoneyViewModel model)
        {
            if (model.Amount <= 0)
            {
                TempData["Error"] = "Amount must be greater than 0";
                return View(model);
            }
           
                await _userService.AddMoney(model);
                TempData["Success"] = $"Successfully added {model.Amount:C} CHF";
                return RedirectToAction("Index");
            
          
        }

        // GET: Printer/SelectFaculty
        public async Task<IActionResult> SelectFaculty()
        {
           var faculties = await _facultyService.GetFaculties();
                return View(faculties);
            
            
        }

        // GET: Printer/AddQuotaToFaculty/{facultyId}
        public async Task<IActionResult> AddQuotaToFaculty(int facultyId)
        {
            
                var faculties = await _facultyService.GetFaculties();
                var faculty = faculties.FirstOrDefault(f => f.FacultyId == facultyId);
                
               

                var users = await _facultyService.GetUsersByFaculty(facultyId);
                
                var viewModel = new AddQuotaToFacultyViewModel
                {
                    FacultyId = facultyId,
                    FacultyName = faculty.Name,
                    Users = users
                };

                return View(viewModel);
            
           
        }

        // POST: Printer/AddQuotaToFaculty
        [HttpPost]
        public async Task<IActionResult> AddQuotaToFaculty(AddQuotaToFacultyViewModel model)
        {
            try
            {
                if (model.Amount <= 0)
                {
                    TempData["Error"] = "Amount must be greater than 0";
                    return RedirectToAction("AddQuotaToFaculty", new { facultyId = model.FacultyId });
                }

                if (model.SelectedUsernames == null || !model.SelectedUsernames.Any())
                {
                    TempData["Error"] = "Please select at least one student";
                    return RedirectToAction("AddQuotaToFaculty", new { facultyId = model.FacultyId });
                }

                foreach (var username in model.SelectedUsernames)
                {
                    var addMoneyRequest = new AddMoneyViewModel
                    {
                        Username = username,
                        Amount = model.Amount
                    };
                    
                    await _userService.AddMoney(addMoneyRequest);
                }

                TempData["Success"] = $"Successfully added {model.Amount:C} CHF to {model.SelectedUsernames.Count} student(s)";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error adding money: " + ex.Message;
                return RedirectToAction("AddQuotaToFaculty", new { facultyId = model.FacultyId });
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}