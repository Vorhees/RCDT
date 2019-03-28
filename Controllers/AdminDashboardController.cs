using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RCDT.Data;
using System.Text.Encodings.Web;
using RCDT.Models;
using System.Linq;

namespace RCDT.Controllers
{
    [Authorize(Policy = "RequireAdminRole")]
    //[Authorize(Roles="admin")]
    public class AdminDashboardController : Controller
    {
        private DataContext _context;

        public AdminDashboardController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Manage()
        {
            return View(_context.Users.ToList());
        }
        

        /*
        public ActionResult Manage()
        {
            
        }
        */
    }
}