using System.ComponentModel.DataAnnotations;
using Inz.Models.Validators;
using Microsoft.AspNetCore.Identity;

namespace Inz.Areas.Identity.Data;

// Add profile data for application users by adding properties to the AppUser class
public class AppUser : IdentityUser
{
    [CustomRequired]
    public string FirstName { get; set; }

   [CustomRequired]
    public string LastName { get; set; }
   
    [CustomRequired]
    public string HomeAddress { get; set; }
   
    [CustomRequired]
    [RegularExpression("^[0-9]*$", ErrorMessage = "Pesel składa się tylko z ")]
    [MaxLength(9, ErrorMessage = "Numer telefonu musi zawierać 9 znaków"), MinLength(9)]
    public string PhoneNumber { get; set; }
    
    [CustomRequired]
    [RegularExpression("^[0-9]*$", ErrorMessage = "Pesel składa się tylko z ")]
    [MaxLength(9, ErrorMessage = "Numer Pesel musi zawierać 11 znaków"), MinLength(9)]
    public string IdentityNumber { get; set; }
    [CustomRequired]

    public int RoleId { get; set; }
}

