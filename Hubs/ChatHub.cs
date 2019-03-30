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
        }
    }
}