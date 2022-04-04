using Office.Data.Entity;
using Office.Models;
using System.Collections.Generic;

namespace Office.Services
{
    public interface IStaffService
    {
       bool CreateStaff(StaffViewModel model);
        List<StaffViewModel> GetStaff();
    }
}
