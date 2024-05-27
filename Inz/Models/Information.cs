using System.ComponentModel.DataAnnotations;

namespace Inz.Models
{
    public class Information
    {
        public int Id { get; set; }

        [Display(Name = "Oddział Pierwszy")]
        public string DepartmentFirst { get; set; }

        [Display(Name = "Oddział Drugi")]
        public string DepartmentSecond { get; set; }

        [Display(Name = "Oddział Trzeci")]
        public string DepartmentThird { get; set; }

        [Display(Name = "Oddział Czwarty")]
        public string DepartmentFourth { get; set; }

        [Display(Name = "Oddział Piąty")]
        public string DepartmentFifth { get; set; }

        [Display(Name = "Informacje Dodatkowe")]
        public string AdditionalInfo { get; set; }
    }
}
