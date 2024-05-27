using Inz.Queries;
using Inz.Controllers.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Inz.Controllers.PatientControllers
{
    [Authorize]
    public class PatientVisitsHistoryController : BaseController
    {
        public async Task<ActionResult> Index(int patientId)
        {
            var response = (await Mediator.Send(new GetAllVisitsByPatientIdQuery.Query
            {
                PatientId = patientId
            })).Value;
            return View(response);
        }
    }
}
