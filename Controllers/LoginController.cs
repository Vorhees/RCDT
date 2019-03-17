using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RCDT.Models;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace RCDT.Controllers
{
    //[Authorize]
    //[Route("[controller]/[action]")]
    public class LoginController : Controller
    {
       // private readonly DataContext _context;
        // GET : /login/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "AdminDashboard");
            }

            return View(loginModel);
        }
    }
}