using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HRwork.Models
{
    public partial class HRDBContext : DbContext
    {
        public HRDBContext()
        {
        }

        public HRDBContext(DbContextOptions<HRDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<JobGrades> JobGrades { get; set; }
        public virtual DbSet<JobHistories> JobHistories { get; set; }
        public virtual DbSet<Jobs> Jobs { get; set; }
        public virtual DbSet<Locations> Locations { get; set; }
        public virtual DbSet<Regions> Regions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Database=HRDB;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Countries>(entity =>
            {
                entity.HasIndex(e => e.RegionsId);

                entity.HasOne(d => d.Regions)
                    .WithMany(p => p.Countries)
                    .HasForeignKey(d => d.RegionsId);
            });

            modelBuilder.Entity<Departments>(entity =>
            {
                entity.HasIndex(e => e.LocationsId);

                entity.Property(e => e.Name).HasMaxLength(30);

                entity.HasOne(d => d.Locations)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.LocationsId);
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasIndex(e => e.DepartmentsId);

                entity.HasIndex(e => e.JobsId);

                entity.Property(e => e.CommissionPct)
                    .HasColumnName("CommissionPCT")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Email).HasMaxLength(25);

                entity.Property(e => e.FirstName).HasMaxLength(20);

                entity.Property(e => e.JobsId).HasMaxLength(10);

                entity.Property(e => e.LastName).HasMaxLength(25);

                entity.Property(e => e.PhoneNumber).HasMaxLength(20);

                entity.Property(e => e.Salary).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Departments)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentsId);

                entity.HasOne(d => d.Jobs)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.JobsId);
            });

            modelBuilder.Entity<JobGrades>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(21);

                entity.Property(e => e.HighestSal).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.LowestSal).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<JobHistories>(entity =>
            {
                entity.HasKey(e => e.StartDate);

                entity.ToTable("jobHistories");

                entity.HasIndex(e => e.DepartmentsId);

                entity.HasIndex(e => e.EmployeesId);

                entity.HasIndex(e => e.JobsId);

                entity.Property(e => e.JobsId).HasMaxLength(10);

                entity.HasOne(d => d.Departments)
                    .WithMany(p => p.JobHistories)
                    .HasForeignKey(d => d.DepartmentsId);

                entity.HasOne(d => d.Employees)
                    .WithMany(p => p.JobHistories)
                    .HasForeignKey(d => d.EmployeesId);

                entity.HasOne(d => d.Jobs)
                    .WithMany(p => p.JobHistories)
                    .HasForeignKey(d => d.JobsId);
            });

            modelBuilder.Entity<Jobs>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(10);

                entity.Property(e => e.JobTitle).HasMaxLength(35);

                entity.Property(e => e.MaxSalary).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.MinSalary).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Locations>(entity =>
            {
                entity.HasIndex(e => e.CountriesId);

                entity.Property(e => e.City).HasMaxLength(30);

                entity.Property(e => e.PostalCode).HasMaxLength(12);

                entity.Property(e => e.StateProvince).HasMaxLength(22);

                entity.Property(e => e.StreetAddress).HasMaxLength(25);

                entity.HasOne(d => d.Countries)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.CountriesId);
            });

            modelBuilder.Entity<Regions>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(25);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
