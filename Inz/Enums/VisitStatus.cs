using System.ComponentModel.DataAnnotations;

namespace Inz.Enums
{
    public enum VisitStatus
    {
        [Display(Name = "Nowa")]
        New,
        [Display(Name = "Oczekująca")]
        Waiting,
        [Display(Name = "W trakcie")]
        during,
        [Display(Name = "Zakończona")]
        finished,
    }
}
