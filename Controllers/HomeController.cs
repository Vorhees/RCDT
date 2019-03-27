using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RCDT.Models;

namespace RCDT.Controllers
{
    public class HomeController : Controller
    {
       // [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult Index(RegisterParticipantViewModel participantViewModel)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Chessboard");
            }

            return View(participantViewModel);
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
