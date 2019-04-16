using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RCDT.Data;
using RCDT.Models;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System;

namespace RCDT.Controllers
{
    [Authorize(Policy = "RequireValidTaskRole")]
    public class ChessboardController : Controller
    {
         private readonly DataContext _context;
         private readonly UserManager<ApplicationUser> _userManager;
         public ChessboardController(DataContext context, UserManager<ApplicationUser> userManager)
         {
             _context = context;
             _userManager = userManager;
         }
         
         public IActionResult Index(string id)
         {
             var user = new ApplicationUser
             {
                 TaskSessionID = id
             };

             return View(user);
         }
         [HttpPost]
         [AllowAnonymous]
         public void addMoveToLog(ChessBoardMoveLog nextMove)
         {
                var move = new ChessBoardMoveLog
                {
                   MoveNumber = nextMove.MoveNumber,
                   TaskSessionID = nextMove.TaskSessionID,
                   UserName = nextMove.UserName,
                   dateTime = DateTime.UtcNow,
                   BoardState = nextMove.BoardState
                };
                _context.ChessBoardMoveLog.Add(move);
                _context.SaveChanges();
         }
    }
}
