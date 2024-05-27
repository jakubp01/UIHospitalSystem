using Inz.Areas.Identity.Data;

namespace Inz.Models
{
    public class VisitDetailsModel
    {
        public InterviewModel? Interview { get; set; }

        public Visit visit { get; set; }
    }
}
