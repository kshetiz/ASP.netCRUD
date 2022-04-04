using Microsoft.AspNetCore.Mvc;
using Office.Data;
using Office.Data.Entity;
using Office.Models;
using Office.Services;

namespace Office.Controllers
{
    [Route("[Controller]")]
    public class StaffController : Controller
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }
        public IActionResult Index()
        {
            var staffList = _staffService.GetStaff();
            return View(staffList);
        }
        [HttpGet("CreateStaff")]
        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost("StaffPost")]
        public IActionResult StaffPost(StaffViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("CreateStaff");
            }
            var createResult = _staffService.CreateStaff(model);
            if (createResult)
                return RedirectToAction("Index");
            else
                return RedirectToAction("CreateStaff");
        }
    }
}
