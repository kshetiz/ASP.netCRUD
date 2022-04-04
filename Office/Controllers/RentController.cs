using Microsoft.AspNetCore.Mvc;
using Office.Data;
using Office.Data.Entity;
using Office.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Office.Controllers
{
    [Route("[Controller]")]
    public class RentController : Controller
    {
        private readonly ApplicationDbContext _context;
        public RentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var dm = _context.RentDetails.ToList();
            var rentToView = new List<RentDetailViewModel>();
            foreach (var items in dm)
            {
                var ren = new RentDetailViewModel();
                ren.Id = items.Id;
                ren.Flat_Name = items.Flat_Name;
                ren.Guest_Name = items.Guest_Name;
                
                ren.Status = items.Status;
                ren.Amount = items.Amount;
                if (ren.Status == true)
                {
                    ren.Availability = "No";
                }
                else
                {
                    ren.Availability = "Yes";
                }
                rentToView.Add(ren);
            }
            return View(rentToView);
        }
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost("Create")]
        public IActionResult Create(RentDetailViewModel mo)
        {
            var st = new RentDetail();
            st.Id = mo.Id;
            st.Flat_Name = mo.Flat_Name;
            
            
            _context.RentDetails.Add(st);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet("Edit/{id}")]
        public IActionResult Edit(int id)
        {
            var ed = _context.RentDetails.Where(x => x.Id == id).FirstOrDefault();
            var de = new RentDetailViewModel();

            de.Id = ed.Id;
            de.Flat_Name = ed.Flat_Name;
            de.Guest_Name = ed.Guest_Name;
            de.Amount = ed.Amount;
            de.Status = ed.Status;
            
            return View(de);
        }
        [HttpPost("EditPost")]
        public IActionResult Edit(RentDetailViewModel edt)
        {
            var std = _context.RentDetails.Where(x => x.Id == edt.Id).FirstOrDefault();
            std.Guest_Name = edt.Guest_Name;
            std.Amount = edt.Amount;
            std.Status = true ;
            
            _context.RentDetails.Update(std);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
