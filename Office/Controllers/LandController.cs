using Microsoft.AspNetCore.Mvc;
using Office.Data;
using Office.Data.Entity;
using Office.Models;
using System.Collections.Generic;
using System.Linq;

namespace Office.Controllers
{
    [Route ("[Controller]")]
    public class LandController : Controller
    {
        private readonly ApplicationDbContext _context;
            public LandController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var data = _context.LandDetails.ToList();
            var landToView = new List<LandDetailViewModel>();
            foreach (var items in data)
            {
                var entity = new LandDetailViewModel();
                entity.Id = items.Id;
                entity.Location = items.Location;
                entity.Area = items.Area;
                landToView.Add(entity);
            }
            return View(landToView);
        }

     
        [HttpGet("Create")]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost("CreatePost")]
        public IActionResult Create(LandDetailViewModel model)
        {
            var entity = new LandDetail();
            entity.Id = model.Id;
            entity.Location = model.Location;
            entity.Area = model.Area;

            _context.LandDetails.Add(entity);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
