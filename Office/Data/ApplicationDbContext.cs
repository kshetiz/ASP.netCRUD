using Microsoft.EntityFrameworkCore;
using Office.Data.Entity;

namespace Office.Data
{
    public class ApplicationDbContext:DbContext

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
           
        }
        public DbSet<RentDetail> RentDetails { get; set; }
        public DbSet<LandDetail> LandDetails { get; set; }
        public DbSet<Staff> Staffs { get; set; }
    }
}
