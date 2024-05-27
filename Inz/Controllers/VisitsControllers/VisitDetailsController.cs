using Inz.CommandsQueries.Queries;
using Inz.Controllers.Core;
using Inz.Models;
using Inz.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inz.Controllers.VisitsControllers
{
    [Authorize]
    public class VisitDetailsController : BaseController
    {
        public async Task<ActionResult> VisitDetails(int VisitId)
        {
            var visit = (await Mediator.Send(new GetSingleVisitQuery.Query { Id = VisitId })).Value;
            var interview = ( await Mediator.Send(new GetVisitInterview.Query { Id = VisitId })).Value;

            var DetailsModel = new VisitDetailsModel
            {
                Interview = interview,
                visit = visit

            };

            return View(DetailsModel);
        }
    }
}
