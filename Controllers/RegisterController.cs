using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace RCDT.Controllers
{
    public class RegisterController : Controller
    {
        // GET : /register/
        public IActionResult Index()
        {
            return View();
        }
    }
}