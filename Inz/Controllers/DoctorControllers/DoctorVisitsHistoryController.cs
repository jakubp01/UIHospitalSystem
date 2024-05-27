using Inz.Queries;
using Inz.Controllers.Core;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Inz.Controllers.DoctorControllers
{
    [Authorize]
    public class DoctorVisitsHistoryController : BaseController
    {
        public async Task<ActionResult> Index()
        {
            var currentLoggedUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var response = (await Mediator.Send(new GetDoctorVisitHistoryQuery.Query
            {
                DoctorId = currentLoggedUserId
            })).Value;
            return View(response);
        }
    }
}
