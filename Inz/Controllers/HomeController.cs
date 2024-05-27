using Azure;
using Inz.Queries;
using Inz.Controllers.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Inz.CommandsQueries.Queries.ChartsRelatedQueries;
using Newtonsoft.Json;

namespace Inz.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        
        public async  Task<ActionResult> Index()
        {
            var currentLoggedUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var closestVisit = (await Mediator.Send(new GetClosestVisitsByDoctorId.Query { DoctorId = currentLoggedUserId })).Value;
            var patientsCount = (await Mediator.Send(new GetAllPatientsQuery.Query { })).Value.Count();
            var visitsCount = (await Mediator.Send(new GetMyVisitsQuery.Query { DoctorId = currentLoggedUserId })).Value.Count();
            var visitsToApproveCount = (await Mediator.Send(new GetVisitsToApproveQuery.Query { DoctorId = currentLoggedUserId })).Value.Count();
            var latestVisits = (await Mediator.Send(new GetLatestVisitsByDoctorIdQuery.Query { DoctorId = currentLoggedUserId })).Value;
            var chartData = (await Mediator.Send(new GetBasicVisitsChartData.Query { Id = currentLoggedUserId })).Value;
            var visitsGrowChartData = (await Mediator.Send(new GetVisitGrowByMonthsDataQuery.Query { Id = currentLoggedUserId })).Value;

            ViewBag.ChartData = chartData;
            ViewBag.LatestVisits = latestVisits;
            ViewBag.patientsCount = patientsCount;
            ViewBag.visitsCount = visitsCount;
            ViewBag.visitsToApproveCount = visitsToApproveCount;
            ViewBag.VisitsGrowChartData = JsonConvert.SerializeObject(visitsGrowChartData);
            return View(closestVisit);
        }

    }
}
