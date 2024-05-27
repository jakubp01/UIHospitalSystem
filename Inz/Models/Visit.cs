using Inz.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace Inz.Models
{
    public class Visit
    {
        public int Id { get; set; }

        [Display(Name = "Data wizyty")]
        public DateTime Date { get; set; }

        [Display(Name = "Wybierz Lekarza")]

        public AppUser doctor { get; set; }

        [Display(Name = "Wybierz profil pacjenta")]
        public Patient patient { get; set; }

        [Display(Name = "Opis Wizyty")]
        public string Desctription { get; set; }


        [Display(Name = "Status")]
        public int Status { get; set; }

        public bool? IsInterviewExist {  get; set; }
    }
}
