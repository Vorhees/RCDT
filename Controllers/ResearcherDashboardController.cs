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
using Microsoft.AspNetCore.Http;
using RCDT.Data;
using Microsoft.EntityFrameworkCore;
using RCDT.Services;
namespace RCDT.Controllers
{
    public class ResearcherDashboardController : Controller
    {
        private DataContext _context;
        //[Authorize(Policy = "RequireResearcherRole")]
        public ResearcherDashboardController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ManageParticipants()
        {
            return View(_context.Users.ToList());
        }

        [HttpGet]
        [Authorize(Policy = "RequireResearcherRole")]
        public IActionResult CreateTask(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public  async Task<IActionResult> CreateTask(TaskModel taskModel, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (ModelState.IsValid)
            {
                var task = new TaskModel { 
                    TaskType = "DDMT", 
                    TaskSessionID = taskModel.TaskSessionID, 
                    participantNumber = taskModel.participantNumber, 
                    confederateNumber = taskModel.confederateNumber, 
                    taskReport = "", 
                    taskTime = DateTime.UtcNow };

                _context.Tasks.Add(task);
               await _context.SaveChangesAsync();

               return RedirectToAction("Index", "ResearcherDashboard");
            }

            return View();
        }

        // private IEnumerable<SelectListItem> GetTaskTypes()
        // {
        //     return new SelectListItem[]
        //     {
        //         new SelectListItem() { Text = "DDMT", Value = "DDMT" },
        //         new SelectListItem() { Text = "TBC", Value = "To be added" }
        //     };
        // }
    }
}