using Inz.CommandsQueries.Commands;
using Inz.Controllers.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Inz.Controllers.DoctorControllers
{
    public class RemoveDoctorController : BaseController
    {
        public ActionResult Remove(string id)
        {

            Mediator.Send(new RemoveDoctorCommand.Command { id = id });
            return RedirectToAction("Index", "DoctorList");

        }
    }
}
