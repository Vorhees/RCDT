using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RCDT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace RCDT.Data
{
    public class DataContext : IdentityDbContext<IDUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
    
        }

        public DbSet<AdminUser> adminUser { get; set; }
        public DbSet<IDUser> admin { get; set; }

        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<AdminUser>().ToTable("Admin");
            base.OnModelCreating(modelBuilder);
        }
        */
        
    }
}