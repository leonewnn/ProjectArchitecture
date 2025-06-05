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

        public PrinterController(IUserService userService, IPrintService printService)
        {
            _userService = userService;
            _printService = printService;
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

            try
            {
                var quota = await _printService.GetQuota(userId);
                return View("QuotaResult", quota);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult AddMoney()
        {
            return View(new AddMoneyViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> AddMoney(AddMoneyViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (string.IsNullOrEmpty(model.CardId) && string.IsNullOrEmpty(model.Username))
            {
                ModelState.AddModelError("", "Provide either Card ID or Username");
                return View(model);
            }

            try
            {
                await _userService.AddMoney(model);
                TempData["Success"] = $"Successfully added {model.Amount:C} CHF";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}