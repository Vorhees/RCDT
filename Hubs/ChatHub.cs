using Microsoft.AspNetCore.SignalR;
using RCDT.Data;
using System.Threading.Tasks;
using RCDT.Models;
using System;
namespace RCDT.Hubs
{
    public class ChatHub : Hub
    {
        //private Models.ApplicationUser user;
        private readonly DataContext _context;

        public ChatHub(DataContext context)
        {
            _context = context;
        }

        public async Task SendMessage(string username, string message)
        {
            //username = user.UserName;

            await Clients.All.SendAsync("ReceiveMessage", username,  message);
            
           // var context = new DataContext();
            var chat = new ChatLog 
            {
                TaskSessionId = 1,
                UserName = username,
                dateTime = DateTime.UtcNow,
                Message = message,
            };
            _context.ChatLog.Add(chat);
            _context.SaveChanges();
            //Save Chat in Database
            //SaveChat(username, message);
        }

    //     private void GetHistory(UserID)
    //     {
    //           // Get Chat History from DB. You got to create a DB class to handle this.
    //           string History = DB.GetChatHistory(UserID); 

    //           // Send Chat History to Client. You got to create chatHistory handler in Client side.
    //           Clients.Caller.chatHistory(History );           
    //     }
    }
}
