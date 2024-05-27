namespace Inz.Models
{
    public class VisitSummary
    {
        public int Id { get; set; }

        public int VisitId { get; set; }

        public string Diagnosis { get; set; }

        public int BillingInfo { get; set; }

        public string FinalDescription { get; set; }
    }
}
