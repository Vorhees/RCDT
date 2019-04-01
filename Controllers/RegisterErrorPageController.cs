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
     public class RegisterErrorPageController : Controller
     {
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }
     }
}