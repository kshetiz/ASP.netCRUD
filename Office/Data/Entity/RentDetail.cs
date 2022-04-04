using System.ComponentModel.DataAnnotations;

namespace Office.Data.Entity
{
    public class RentDetail
    {

        [Key]
        public int Id { get; set; }
        public string Flat_Name { get; set; }
        public string Guest_Name { get; set; }
        public int Amount { get; set; }
        public bool Status { get; set; }

    }
}
