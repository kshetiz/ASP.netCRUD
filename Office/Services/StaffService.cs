using Office.Data;
using Office.Data.Entity;
using Office.Models;
using System.Collections.Generic;
using System.Linq;

namespace Office.Services
{
    public class StaffService : IStaffService
    {
        private readonly ApplicationDbContext _context;

        public StaffService(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool CreateStaff(StaffViewModel model)
        {
            var staffEntity = new Staff();
            staffEntity.Name = model.Name;
            staffEntity.Age = model.Age;
            _context.Staffs.Add(staffEntity);
            _context.SaveChanges();
            return true;
        }
        public List<StaffViewModel> GetStaff()
        {
            var staff = _context.Staffs.ToList();
            var staffList = new List<StaffViewModel>();
            foreach (var item in staff)
            {
                var s = new StaffViewModel();
                s.Id = item.Id;
                s.Name = item.Name;
                s.Age = item.Age;
                staffList.Add(s);
            }
            return staffList;
        }
    }
}
