/**
    Sample CRUD operation to test. Still in progress
*/

using System.Collections.Generic;
using System.Linq;
using RCDT.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace RCDT.Services
{
    public class AdminUserService
    {
        private readonly IMongoCollection<AdminUser> _adminUsers;

        public AdminUserService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("RCDTDb"));
            var database = client.GetDatabase("RCDTDb");
            _adminUsers = database.GetCollection<AdminUser>("Admin");
        }

        public List<AdminUser> GetAdminUsers()
        {
            return _adminUsers.Find(adminUser => true).ToList();
        }

        public AdminUser GetAdmin(string id)
        {
            return _adminUsers.Find<AdminUser>(adminUser => adminUser.Id == id).FirstOrDefault();
        }

        public AdminUser Create(AdminUser adminUser)
        {
            _adminUsers.InsertOne(adminUser);
            
            return adminUser;
        }

        public void Update(string id, AdminUser adminUserIn)
        {
            _adminUsers.ReplaceOne(adminUser => adminUser.Id == id, adminUserIn);
        }

        public void Remove(AdminUser adminUserIn)
        {
            _adminUsers.DeleteOne(adminUser => adminUser.Id == adminUserIn.Id);
        }

        public void Remove(string id)
        {
            _adminUsers.DeleteOne(adminUser => adminUser.Id == id);
        }
    }
}