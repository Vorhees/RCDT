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
            
            //Save Chat in Database, need to figure out how our db is set up
            //DB.SaveChat(username, message);

        }
    //    public override System.Threading.Tasks.Task OnConnected()
    //     {
    //           // Get UserID. Assumed the user is logged before connecting to chat and userid is saved in session.
    //           string UserID = (string)HttpContext.Current.Session["userid"];

    //           // Get ChatHistory and call the client function. See below
    //           this.GetHistory(UserID); 

    //           // Get ConnID
    //           string ConnID =  Context.ConnectionId; 

    //           // Save them in DB. You got to create a DB class to handle this. (Optional)
    //           //DB.UpdateConnID(UserID, ConnID); 
    //     }

    //     private void GetHistory(UserID)
    //     {
    //           // Get Chat History from DB. You got to create a DB class to handle this.
    //           string History = DB.GetChatHistory(UserID); 

    //           // Send Chat History to Client. You got to create chatHistory handler in Client side.
    //           Clients.Caller.chatHistory(History );           
    //     }
    }
}
