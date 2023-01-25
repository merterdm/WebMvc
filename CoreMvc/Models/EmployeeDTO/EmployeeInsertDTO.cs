using System.ComponentModel.DataAnnotations;

namespace CoreMvc.Models.EmployeeDTO
{
    public class EmployeeInsertDTO
    {

        [Required(AllowEmptyStrings = false, ErrorMessage = "Ad Alani Boş Gecilemez")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Soyad Alani Boş Gecilemez")]

        public string LastName { get; set; }
        public string? Title { get; set; }
        public DateTime? BirtDate { get; set; }
    }
}
