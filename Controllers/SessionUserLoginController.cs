using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RCDT.Models;
using System.Text.Encodings.Web;
using System.Threading.Tasks;


namespace RCDT.Controllers
{
    [Authorize(Roles = "Participant")]
    public class SessionUserLoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(SessionUserModel loginModel)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Dashboard");
            }

            return View(loginModel);
        }
    }
}