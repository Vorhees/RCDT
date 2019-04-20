using Microsoft.AspNetCore.SignalR;
using RCDT.Data;
using System.Threading.Tasks;
using RCDT.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace RCDT.Hubs
{
    public class ChatHub : Hub
    {
        //private Models.ApplicationUser user;
        private readonly DataContext _context;
        // private static int countOfUsers = 0;
        // private static int validUsers = 0;
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

        public async Task JoinGroup(string group)
        {
            // var task = _context.Users.Where(taskID => taskID.TaskSessionID == group);

            // validUsers = task.Count();
            
            // Console.WriteLine("Total number of users in group: " + validUsers);

            // // if (countOfUsers < validUsers)
            // // {
            // //     Console.WriteLine("NOT ENOUGH MEMBERS CONNECTED");
            // // }
            // // else
            // // {
            // //     Console.WriteLine("Enough members connected, You may begin the task");
            // // }

            // countOfUsers++;
            // Console.WriteLine("Number of users connected: " + countOfUsers);

            await Groups.AddToGroupAsync(Context.ConnectionId, group);
            
        }

        // public bool taskStartCheck()
        // {
        //     bool flag = false;

        //     if (countOfUsers < validUsers)
        //     {
        //         Console.WriteLine("NOT ENOUGH MEMBERS CONNECTED");
        //     }
        //     else
        //     {
        //         Console.WriteLine("Enough members connected, You may begin the task");
        //         flag = true;
        //     }

        //     return flag;
        // }

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

            UserCount.connectedUsers.Add(Context.ConnectionId);

            UserCount.count = UserCount.connectedUsers.Count;

            await Clients.All.SendAsync("UserConnected", Context.ConnectionId, UserCount.count);

            Console.WriteLine("Users connected: " + UserCount.count);

            await base.OnConnectedAsync();
        }

        // public async Task usersJoined()
        // {
        //     await Clients.All.SendAsync("UserNumber", UserCount.count);
        // }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            // // Temporary
            // countOfUsers = 0;
            // validUsers = 0;

            await Clients.All.SendAsync("UserDisconnected", Context.ConnectionId);

            UserCount.connectedUsers.Remove(Context.ConnectionId);

            UserCount.count = UserCount.connectedUsers.Count;

            Console.WriteLine("Users connected: " + UserCount.count);

            await base.OnDisconnectedAsync(exception);
        }
    }

    public static class UserCount
    {
        public static HashSet<string> connectedUsers = new HashSet<string>();

        [JsonProperty("count")]
        public static int count { get; set; }
    }
}
