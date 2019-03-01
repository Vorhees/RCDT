using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace RCDT.Controllers
{
    public class DashboardController : Controller
    {
       // [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}