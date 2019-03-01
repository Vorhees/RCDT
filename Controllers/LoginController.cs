using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RCDT.Models;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace RCDT.Controllers
{
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