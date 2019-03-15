using RCDT.Models;
using System;
using System.Linq;

namespace RCDT.Data
{
    public static class SeedDb
    {
        public static void Initialize(DataContext context)
        {
            context.Database.EnsureCreated();

            if (context.adminUser.Any())
            {
                return; // Db is seeded if any admin user is found.
            }

            var adminUsers = new AdminUser[]
            {
                new AdminUser {Username="jimmyN123", Password="12345", Email="jimmy@gmail.com"},
                new AdminUser {Username="isaiahF123", Password="123454", Email="isaiah@gmail.com"},
                new AdminUser {Username="bobbyN123", Password="1234425", Email="bobby@gmail.com"},
                new AdminUser {Username="vuD123", Password="42312345", Email="vu@gmail.com"},
            };

            foreach (AdminUser a in adminUsers)
            {
                context.adminUser.Add(a);
            }

            context.SaveChanges();
        }
    }
}