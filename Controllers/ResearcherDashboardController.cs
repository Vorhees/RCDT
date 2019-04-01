using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RCDT.Data;
using RCDT.Models;

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
    }
}