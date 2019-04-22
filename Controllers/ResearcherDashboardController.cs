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
        private UserManager<ApplicationUser> _userManager;
        
        //[Authorize(Policy = "RequireResearcherRole")]
        public ResearcherDashboardController(DataContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
 
        public IActionResult Index()
        {
            return View(_context.Tasks.ToList());
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
                    taskCreatedTime = DateTime.UtcNow };

                _context.Tasks.Add(task);
               await _context.SaveChangesAsync();

               return RedirectToAction("Index", "ResearcherDashboard");
            }

            return View();
        }

        public async Task<IActionResult> EditTask(string id)
        {
            if (id == null)
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
                TaskType = "DDMT",
                participantNumber = task.participantNumber,
                confederateNumber = task.confederateNumber,
                taskEditedTime = task.taskEditedTime
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTask(TaskModel tm, string id)
        {
            var task = await _context.Tasks.FindAsync(id);

            task.TaskSessionID = task.TaskSessionID;
            task.TaskType = "DDMT";
            task.participantNumber = tm.participantNumber;
            task.confederateNumber = tm.confederateNumber;
            task.taskEditedTime = DateTime.Now;

            _context.Tasks.Update(task);
            _context.SaveChanges();

            return RedirectToAction("Index", "ResearcherDashboard");
        }

        public async Task<IActionResult> DeleteTask(string id)
        {
            if (id == null)
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
        public async Task<IActionResult> Delete(string id)
        {
            var task = await _context.Tasks.FindAsync(id);

            _context.Remove<TaskModel>(task);
            _context.SaveChanges();

            return RedirectToAction("Index", "ResearcherDashboard");
        }

        public IActionResult ViewTask(string id)
        {
            // if (id == null)
            // {
            //     return NotFound();
            // }

            var task = _context.ChatLog.Where(taskID => taskID.TaskSessionId == id).ToList();

            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        public IActionResult ViewBoardMoves(string id)
        {
            var taskSesh = _context.ChessBoardMoveLog.Where(taskID => taskID.TaskSessionID == id).ToList();

            if (taskSesh == null)
            {
                return NotFound();
            }

            return View(taskSesh);
        }

        public async Task<IActionResult> DeleteParticipant(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByNameAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(new ApplicationUser
            {
                UserName = user.UserName,
                ParticipantUserId = user.ParticipantUserId,
                Role = user.Role
            });
        }

        [HttpPost, ActionName("DeleteParticipant")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ParticipantDelete(string id)
        {
            var user = await _userManager.FindByNameAsync(id);
            await _userManager.DeleteAsync(user);

            return RedirectToAction("ManageParticipants", "ResearcherDashboard");
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