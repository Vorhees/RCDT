using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RCDT.Models;

namespace RCDT.Controllers
{
    public class HomeController : Controller
    {
        private UserManager<ApplicationUser> _userManager;

        public HomeController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

       // [Authorize(Roles = "Admin")]
        public IActionResult Index(ApplicationUser user)
        {
            return View(user);
        }

        public async Task<IActionResult> ResumeTask(string id)
        {
            var user = await _userManager.FindByNameAsync(id);

            return RedirectToAction("Index", "Chessboard", new {id = user.TaskSessionID});
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
