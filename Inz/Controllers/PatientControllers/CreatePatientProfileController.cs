using Inz.Queries;
using Inz.Controllers.Core;
using Inz.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Inz.CommandsQueries.Commands;
using Inz.Models.Validators;
using FluentValidation.Results;

namespace Inz.Controllers.CreateControllers
{
    [Authorize]
    public class CreatePatientProfileController : BaseController
    {
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Patient model)
        {
            PatientValidator validator = new PatientValidator();
            ValidationResult result = validator.Validate(model);

            if(result.IsValid) { 
            Mediator.Send(new CreatePatientCommand.Command { patient = model });
            return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
    }
}
