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
     public class ErrorPagesController : Controller
     {
        [Authorize(Roles = "Admin")]
        public IActionResult RegisterError()
        {
            return View();
        }

        [Authorize(Roles = "Admin, Researcher")]
        public IActionResult TaskCapacityError()
        {
            return View();
        }
     }
}