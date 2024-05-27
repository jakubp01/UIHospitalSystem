using Inz.Queries;
using Inz.Controllers.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Inz.CommandsQueries.Commands;

namespace Inz.Controllers.PatientControllers
{
    [Authorize]
    public class PatientListController : BaseController
    {
        public async Task<ActionResult> Index()
        {
            var response = (await Mediator.Send(new GetAllPatientsQuery.Query
            {
            })).Value;
            return View(response);
        }

    }
}
