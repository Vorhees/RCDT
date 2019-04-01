using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RCDT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace RCDT.Data
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        /*
        public DataContext() : base()
        {
            
        }
        */

       // public DbSet<AdminUser> adminUser { get; set; }
        //public DbSet<ApplicationUser> ApplicationUser { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<AdminUser>().ToTable("Admin");
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
            .Ignore(col => col.PhoneNumber)
            .Ignore(col => col.PhoneNumberConfirmed)
            .Ignore(col => col.TwoFactorEnabled)
            .Ignore(col => col.AccessFailedCount)
            .Ignore(col => col.LockoutEnd);

            modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");

            // modelBuilder.Entity<ApplicationUser>(mb => {
            //     mb.Property( u => u.UserName).
            // })
        }
    }
}