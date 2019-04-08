using Microsoft.AspNetCore.SignalR;
using RCDT.Data;
using System.Threading.Tasks;

namespace RCDT.Hubs
{
    public class ChatHub : Hub
    {
        //private Models.ApplicationUser user;
        public async Task SendMessage(string username, string message)
        {
            //username = user.UserName;

            await Clients.All.SendAsync("ReceiveMessage", username,  message);
            
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
