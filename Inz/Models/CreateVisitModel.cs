using Inz.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace Inz.Models
{
    public class CreateVisitModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string doctor { get; set; }
        
        public int patient { get; set; }
        
        public string Desctription { get; set; }

        public int Status { get; set; }

    }
}
