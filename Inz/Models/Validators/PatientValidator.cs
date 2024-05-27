using FluentValidation;

namespace Inz.Models.Validators
{
    public class PatientValidator : AbstractValidator<Patient>
    {
        public PatientValidator()
        {
            RuleFor(patient => patient.FirstName)
                .NotEmpty().WithMessage("Imię jest wymagane.");

            RuleFor(patient => patient.LastName)
                .NotEmpty().WithMessage("Nazwisko jest wymagane.")
                .MaximumLength(50).WithMessage("Nazwisko nie może być dłuższe niż 50 znaków.");

            RuleFor(patient => patient.EmailAddress)
                .NotEmpty().WithMessage("Adres email jest wymagany.")
                .MaximumLength(255).WithMessage("Adres email nie może być dłuższy niż 255 znaków.")
                .Matches(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")
                    .WithMessage("Nieprawidłowy format adresu email.");

            RuleFor(patient => patient.HomeAddress)
                .NotEmpty().WithMessage("Adres zamieszkania jest wymagany.")
                .MaximumLength(50).WithMessage("Adres zamieszkania nie może być dłuższy niż 50 znaków.");

            RuleFor(patient => patient.IdentificationNumber)
                .NotEmpty().WithMessage("Pesel jest wymagany.")
                .Matches("^[0-9]*$").WithMessage("Pesel musi składać się tylko z cyfr.")
                .Length(11).WithMessage("Pesel musi zawierać 11 znaków.");

            RuleFor(patient => patient.PhoneNumber)
                .NotEmpty().WithMessage("Numer telefonu jest wymagany.")
                .Matches("^[0-9]*$").WithMessage("Numer telefonu musi składać się tylko z cyfr.")
                .Length(9).WithMessage("Numer telefonu musi zawierać 9 znaków.");
        }
    }
}
