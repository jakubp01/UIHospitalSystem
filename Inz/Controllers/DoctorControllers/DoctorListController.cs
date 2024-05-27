using Inz.Queries;
using Inz.Controllers.Core;
using Microsoft.AspNetCore.Mvc;
using Inz.CommandsQueries.Queries;
using Microsoft.AspNetCore.Authorization;

namespace Inz.Controllers.DoctorControllers
{
    [Authorize][Authorize]
    public class DoctorListController : BaseController
    {
        public async Task<ActionResult> Index()
        {
            var response = (await Mediator.Send(new GetAllDoctorsQuery.Query { })).Value;
            return View(response);
        }
    }
}
