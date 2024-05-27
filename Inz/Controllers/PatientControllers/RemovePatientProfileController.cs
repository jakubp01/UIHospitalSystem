using Inz.CommandsQueries.Commands;
using Inz.Models.Validators;
using Inz.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Inz.Controllers.Core;

namespace Inz.Controllers.PatientControllers
{
    public class RemovePatientProfileController : BaseController
    {
        public ActionResult Remove(int id)
        {

            Mediator.Send(new RemovePatientProfileCommand.Command { id = id });
            return RedirectToAction("Index", "PatientList");

        }
    }
}
