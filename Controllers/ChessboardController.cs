using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RCDT.Models;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace RCDT.Controllers
{
    //[Authorize(Roles = "Participant")]
    public class ChessboardController : Controller
    {
         public IActionResult Index()
        {
            return View();
        }

        public ActionResult boardClick(string id)
        {
            if (id == "8a")
            {
                RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}