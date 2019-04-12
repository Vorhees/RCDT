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

        public IActionResult Index(int id)
        {
            return View();
        }
        
        public IActionResult StartTask()
        {
            return View();
        }

        public IActionResult ManageParticipants()
        {
            return View(_context.Users.ToList());
        }

        public IActionResult ManageTasks()
        {
            return View(_context.Tasks.ToList());
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

        public async Task<IActionResult> DeleteTask(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var task = await _context.Tasks.FindAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            return View(new TaskModel
            {
                TaskSessionID = task.TaskSessionID,
                TaskType = task.TaskType,
                participantNumber = task.participantNumber,
                confederateNumber = task.confederateNumber
            });
        }

        [HttpPost, ActionName("DeleteTask")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var task = await _context.Tasks.FindAsync(id);

            _context.Remove<TaskModel>(task);
            _context.SaveChanges();

            return RedirectToAction("ManageTasks", "ResearcherDashboard");
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