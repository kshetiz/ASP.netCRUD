using System.ComponentModel.DataAnnotations;

namespace Office.Models
{
    public class StaffViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
