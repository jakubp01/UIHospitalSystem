using Azure;
using Inz.Areas.Identity.Data;
using Inz.Queries;
using Inz.Controllers.Core;
using Inz.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Security.Claims;
using Inz.CommandsQueries.Queries;
using Inz.CommandsQueries.Commands;
using Microsoft.AspNetCore.Authorization;

namespace Inz.Controllers.GetControllers
{
    [Authorize]
    public class MyVisitsController : BaseController
    {
        public async Task<ActionResult> Index()
        {
            var currentLoggedUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var response = (await Mediator.Send(new GetMyVisitsQuery.Query
            {
                DoctorId = currentLoggedUserId
            })).Value;
            return View(response);
        }

        public async Task<ActionResult> Edit(int id)
        {

            var response = (await Mediator.Send(new GetSingleVisitQuery.Query { Id = id })).Value;
            var doctors = (await Mediator.Send(new GetAllDoctorsQuery.Query())).Value;
            var patients = (await Mediator.Send(new GetAllPatientsQuery.Query())).Value;

            var doctorSelectList = CreateSelectList(doctors);
            var patientSelectList = CreateSelectListForPatients(patients);

            ViewBag.PatientSelectList = patientSelectList;
            ViewBag.DoctorSelectList = doctorSelectList;
            ViewBag.PatientId = response.patient.Id.ToString();
            ViewBag.DoctorId = response.doctor.Id.ToString();

            return View(response);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CreateVisitModel model)
        {
            Mediator.Send(new UpdateVisitCommand.Command { visit = model });
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        public async Task<ActionResult> CreateInterview(int id)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateInterview(int id, InterviewModel model)
        {
            
            model.VisitId = id;
            model.Id = 0;
            await Mediator.Send(new AddInterviewCommand.Command { interview = model });

            return RedirectToAction("Index", "Home");
        }

        private SelectList CreateSelectList(IEnumerable<AppUser> doctors)
        {
            return new SelectList(doctors.Select(d => new SelectListItem
            {
                Text = $"{d.FirstName} {d.LastName}",
                Value = d.Id.ToString()
            }), "Value", "Text");
        }

        private SelectList CreateSelectListForPatients(List<Patient> patients)
        {
            return new SelectList(patients.Select(p => new SelectListItem
            {
                Text = $"{p.FirstName} {p.LastName}",
                Value = p.Id.ToString()
            }), "Value", "Text");
        }

    }
}
