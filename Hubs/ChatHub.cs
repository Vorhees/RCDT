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
       // private readonly TaskModel taskModel;

        public int messageID = 0;

        public ChatHub(DataContext context)
        {
            _context = context;
        }

        // public async Task SendMessage(string username, string message)
        // {
        //     //username = user.UserName;

        //     await Clients.All.SendAsync("ReceiveMessage", username,  message);
            
        //    // var context = new DataContext();
        //     var chat = new ChatLog 
        //     {
        //         TaskSessionId = 1,
        //         UserName = username,
        //         dateTime = DateTime.UtcNow,
        //         Message = message,
        //         MessageId = messageID,
        //     };

        //     _context.ChatLog.Add(chat);
        //     _context.SaveChanges();
        //     // Save Chat in Database
        //     // SaveChat(username, message);
        // }

        public Task JoinGroup(string group)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, group);
        }

        public async Task SendMessageToGroup(string group, string username, string message)
        {
            await Clients.Group(group).SendAsync("ReceiveMessage", username, message);

            var chat = new ChatLog 
            {
                TaskSessionId = group,
                UserName = username,
                dateTime = DateTime.UtcNow,
                Message = message,
                MessageId = messageID,
            };
            _context.ChatLog.Add(chat);
            _context.SaveChanges();
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("UserConnected", Context.ConnectionId);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Clients.All.SendAsync("UserDisconnected", Context.ConnectionId);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
