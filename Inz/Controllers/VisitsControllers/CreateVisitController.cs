using Inz.Areas.Identity.Data;
using Inz.Queries;
using Inz.Controllers.Core;
using Inz.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Inz.CommandsQueries.Queries;
using Inz.CommandsQueries.Commands;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using NuGet.Protocol;
using Microsoft.AspNetCore.Identity;
using Inz.Enums;

namespace Inz.Controllers.CreateControllers
{
    [Authorize]
    public class CreateVisitController : BaseController
    {
        private readonly UserManager<AppUser> _userManager;
        public CreateVisitController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ActionResult> Create()
        {
            var user = await _userManager.GetUserAsync(User);
            var currentLoggedUserId = user.Id;

            List<AppUser> doctors = new List<AppUser>();
           

            if  (user.RoleId == (int)Roles.Doctor){
                 
                var doctorsList = (await Mediator.Send(new GetAllDoctorsQuery.Query())).Value.FirstOrDefault(x => x.Id == currentLoggedUserId);
                doctors.Add(doctorsList);
            }
            else if(user.RoleId == (int)Roles.Receptionist) { 
                           doctors = (await Mediator.Send(new GetAllDoctorsQuery.Query())).Value;
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            var patients = (await Mediator.Send(new GetAllPatientsQuery.Query())).Value;

            var doctorSelectList = CreateSelectList(doctors);
            var patientSelectList = CreateSelectListForPatients(patients);
            
            ViewBag.PatientSelectList = patientSelectList;
            ViewBag.DoctorSelectList = doctorSelectList;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateVisitModel model)
        {

            Mediator.Send(new CreateVisitCommand.Command { visit = model });
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

        private async Task<bool> IsUserADoctor(string userId)
        {
            var userToCheck = (await Mediator.Send(new GetSingleDoctorQuery.Query {  Id = userId })).Value;
            if(userToCheck.RoleId == 1)
            {
                return true;
            
                    }
            return false;
        }

    }
}
