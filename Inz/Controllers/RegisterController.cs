using Inz.Areas.Identity.Data;
using Inz.Controllers.Core;
using Inz.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Praca_inżynierska.Controllers
{
    //[Authorize(Roles ="Admin")]

    [Authorize]
    public class RegisterController : BaseController
    {
        private readonly UserManager<AppUser> _userManager;
        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<ActionResult> Register()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user.RoleId == (int)Roles.Admin)
            {
                return Redirect("/Identity/Account/Register");
            }
            else return Redirect("/Home/Index");
           
            
        }
    }
}
