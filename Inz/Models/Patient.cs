using Inz.Models.Validators;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Inz.Models
{
   
    public class Patient
    {
        public int Id { get; set; }
        
        [Display(Name = "Imię")]
        [CustomRequired]
        public string FirstName { get; set; }

        [MaxLength(50)]
        [Display(Name = "Nazwisko")]
        [CustomRequired]
        public string LastName { get; set; }
        
        [MaxLength(255)]
        [Display(Name = "Email")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Nieprawidłowy format adresu email.")]
        [CustomRequired]
        public string EmailAddress { get; set; }
        
        [MaxLength(50, ErrorMessage = "Pole przyjmuje maksymalnie 50 znaków")]
        [Display(Name = "Adres Zamieszkania")]
        [CustomRequired]
        public string HomeAddress { get; set; }

        [Display(Name = "Pesel")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "To pole przyjmuje jedynie cyfry")]
        [MaxLength(11, ErrorMessage = "Pesel telefonu musi zawierać 11 znaków"), MinLength(11)]
        [CustomRequired]
        public string IdentificationNumber { get; set; }
        
        [Display(Name = "Numer Telefonu")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Pesel składa się tylko z ")]
        [MaxLength(9, ErrorMessage = "Numer telefonu musi zawierać 9 znaków"), MinLength(9)]
        [CustomRequired]
        public string PhoneNumber { get; set; }
    }
}
