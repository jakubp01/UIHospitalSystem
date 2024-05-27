using Inz.Queries;
using Inz.Controllers.Core;
using Inz.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Inz.CommandsQueries.Commands;
using Microsoft.AspNetCore.Authorization;

namespace Inz.Controllers.GetControllers
{
    [Authorize]
    public class VisitToApproveController : BaseController
    {
        public async Task<ActionResult> Index()
        {
            var currentLoggedUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var response = (await Mediator.Send(new GetVisitsToApproveQuery.Query
            {
                DoctorId = currentLoggedUserId,
            })).Value;
            return View(response);
        }

        public async Task<ActionResult> Approve(Visit model)
        {
            await Mediator.Send(new ApproveVisitCommand.Command { Id = model.Id });
            return RedirectToAction(nameof(Index));
        }

    }
}
