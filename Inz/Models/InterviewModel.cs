using Inz.Models.Validators;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inz.Models
{
    public class InterviewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int VisitId { get; set; }

        [Display(Name = "Ból Głowy")]
        [Column(TypeName = "bit")]
        public bool IsHeadache { get; set; }

        [Display(Name = "Kaszel")]
        [Column(TypeName = "bit")]
        public bool isCough { get; set; }

        [Display(Name = "Katar")]
        [Column(TypeName = "bit")]
        public bool isRunnyNose { get; set; }

        [Display(Name = "Podwyższona temperatura")]
        [Column(TypeName = "bit")]
        public bool HigherTemperature { get; set; }

        [Display(Name = "Ból Mięśni")]
        [Column(TypeName = "bit")]
        public bool MuscleAches { get; set; }

        [Display(Name = "Dreszcze")]
        [Column(TypeName = "bit")]
        public bool IsChills { get; set; }

        [Display(Name = "Ból Brzucha")]
        [Column(TypeName = "bit")]
        public bool IsStomachache { get; set; }

        [Display(Name = "Bóle ogółem")]
        [Column(TypeName = "bit")]
        public bool IsAnyPain { get; set; }

        [Display(Name = "Zmęczenie")]
        [Column(TypeName = "bit")]
        public bool IsPatientFeelsTired { get; set; }

        [Display(Name = "Zawroty Głowy")]
        [Column(TypeName = "bit")]
        public bool IsDizziness { get; set; }

        [Display(Name = "Opis Gardła")]
        public string ThroatOpinion { get; set; }

        [Display(Name = "Oddech badany z przodu")]
        [CustomRequired]
        public string BreathFromFrontOpinion { get; set; }

        [Display(Name = "Oddech badany z tyłu")]
        [CustomRequired]
        public string BreathFromBacktOpinion { get; set; }

        [Display(Name = "Ciśnienie krwi")]
        [CustomRequired]
        public string BloodPressure { get; set; }

    }
}
