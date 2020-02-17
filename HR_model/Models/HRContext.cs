using HR_model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Models
{
    public class HRContext : DbContext
    {
        public DbSet<Countries> Countries { get; set; }

        public DbSet<Departments> Departments { get; set; }

        public DbSet<Employees> Employees { get; set; }

        public DbSet<JobGrades> JobGrades { get; set; }

        public DbSet<JobHistory> jobHistories { get; set; }

        public DbSet<Jobs> Jobs { get; set; }

        public DbSet<Locations> Locations { get; set; }

        public DbSet<Regions> Regions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Database=database_HR;Trusted_Connection=True;");
        }
    }
}
