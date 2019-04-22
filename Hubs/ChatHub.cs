using Microsoft.AspNetCore.SignalR;
using RCDT.Data;
using System.Threading.Tasks;
using RCDT.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace RCDT.Hubs
{
    public class ChatHub : Hub
    {
        //private Models.ApplicationUser user;
        private readonly DataContext _context;
        private UserManager<ApplicationUser> _userManager;
        // private static int countOfUsers = 0;
        public static int totalUsers;
       // private readonly TaskModel taskModel;

        public int messageID = 0;

        public ChatHub(DataContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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
            var task = _context.Users.Where(taskID => taskID.TaskSessionID == group);

            totalUsers = task.Count();

            await Groups.AddToGroupAsync(Context.ConnectionId, group);
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
            var user = await _userManager.FindByNameAsync(Context.User.Identity.Name);
            var isResearcher = await _userManager.IsInRoleAsync(user, "Researcher");
            var isParticipant = await _userManager.IsInRoleAsync(user, "Participant");

            Console.WriteLine("Total users in group: " + totalUsers);

            // if (isResearcher)
            // {
            //     UserCount.UserList.Add(new KeyValuePair<string, string>("Researcher", Context.ConnectionId));
            // }

            if (!isResearcher && isParticipant)
            {
                // UserCount.UserList.Add(new KeyValuePair<string, string>(user.TaskSessionID, Context.ConnectionId));

                UserCount.taskList.Add(user.TaskSessionID);
                Console.WriteLine("Added: " + user.TaskSessionID);
            }

            foreach (var item in UserCount.taskList)
            {
                Console.WriteLine("Item in list: " + item);
            }

            var res = UserCount.taskList.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            
            foreach (var item in res)
            {
                Console.WriteLine("Key:" + item.Key + " | Value:" + item.Value);

                if (user.TaskSessionID == item.Key)
                {
                    UserCount.count = res[item.Key];

                    Console.WriteLine("Value is: " + UserCount.count);
                }
            }

            await Clients.All.SendAsync("UserConnected", Context.ConnectionId, UserCount.count);
            
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Clients.All.SendAsync("UserDisconnected", Context.ConnectionId);

            // UserCount.connectedUsers.Remove(Context.ConnectionId);

            // UserCount.count = UserCount.connectedUsers.Count;

            Console.WriteLine("Users connected: " + UserCount.count);

            await base.OnDisconnectedAsync(exception);
        }
    }

    public static class UserCount
    {
        // public static Dictionary<string, string> UserList = new Dictionary<string, string>();

        // public static List<KeyValuePair<string, string>> UserList = new List<KeyValuePair<string,string>>();

        public static List<string> taskList = new List<string>();

        // public static HashSet<string> groupName = new HashSet<string>();
        public static int count { get; set; }
        public static int researcherCount { get; set; }
    }
}
