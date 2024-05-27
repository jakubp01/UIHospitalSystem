using System.ComponentModel.DataAnnotations;

namespace Inz.Models.Validators
{
    public class CustomRequiredAttribute : RequiredAttribute
    {
        public CustomRequiredAttribute()
        {
            ErrorMessage = "To pole jest wymagane.";
        }
    }
}
