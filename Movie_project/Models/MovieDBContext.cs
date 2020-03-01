using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movie_project.Models
{
    class MovieDBContext: DbContext
    {
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Genres> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieCast> MovieCasts { get; set; }
        public DbSet<MovieDirection> MovieDirections { get; set; }
        public DbSet<MovieGenres> MovieGenres { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Database=MovieDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>()
                .HasKey(actor => actor.Id);

            modelBuilder.Entity<Actor>()
                .Property(actor => actor.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Actor>()
                .Property(actor => actor.FirstName)
                .HasMaxLength(20);

            modelBuilder.Entity<Actor>()
                .Property(actor => actor.LastName)
                .HasMaxLength(20);

            modelBuilder.Entity<Regions>()
                .Property(region => region.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Regions>()
                .Property(region => region.Name)
                .HasMaxLength(25);

            modelBuilder.Entity<Regions>()
                .HasMany<Countries>(region => region.Countries)
                .WithOne(country => country.Regions);

            modelBuilder.Entity<Countries>()
                .HasKey(country => country.Id);

            modelBuilder.Entity<Countries>()
                .Property(country => country.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Countries>()
                .Property(country => country.Id)
                .HasMaxLength(2);

            modelBuilder.Entity<Countries>()
                .Property(country => country.Name)
                .HasMaxLength(40);

            modelBuilder.Entity<Countries>()
                .HasMany<Locations>(countries => countries.Locations)
                .WithOne(location => location.Countries);

            modelBuilder.Entity<Locations>()
                .HasKey(location => location.Id);

            modelBuilder.Entity<Locations>()
                .Property(location => location.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Locations>()
                .Property(location => location.StreetAddress)
                .HasMaxLength(25);

            modelBuilder.Entity<Locations>()
                .Property(location => location.PostalCode)
                .HasMaxLength(12);

            modelBuilder.Entity<Locations>()
                .Property(location => location.City)
                .HasMaxLength(30);

            modelBuilder.Entity<Locations>()
                .Property(location => location.StateProvince)
                .HasMaxLength(12);

            modelBuilder.Entity<Locations>()
                .HasMany<Departments>(department => department.Departments)
                .WithOne(location => location.Locations);

            modelBuilder.Entity<Departments>()
                .HasKey(departments => departments.Id);

            modelBuilder.Entity<Departments>()
                .Property(departments => departments.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Departments>()
                .Property(departments => departments.Name)
                .HasMaxLength(30);

            modelBuilder.Entity<Departments>()
                .HasMany<Employees>(employees => employees.Employees)
                .WithOne(departments => departments.Departments);

            modelBuilder.Entity<Employees>()
                .HasKey(employee => employee.Id);

            modelBuilder.Entity<Employees>()
                .Property(employee => employee.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Employees>()
                .Property(employee => employee.FirstName)
                .HasMaxLength(20);

            modelBuilder.Entity<Employees>()
                .Property(employee => employee.LastName)
                .HasMaxLength(25);

            modelBuilder.Entity<Employees>()
                .Property(employee => employee.Email)
                .HasMaxLength(25);

            modelBuilder.Entity<Employees>()
                .Property(employee => employee.PhoneNumber)
                .HasMaxLength(20);

            modelBuilder.Entity<JobHistories>()
                .HasKey(jobHist => new { jobHist.EmployeesId, jobHist.StartDate });

            modelBuilder.Entity<JobHistories>()
                 .Property(jobHist => jobHist.JobId)
                 .HasMaxLength(10);

            modelBuilder.Entity<JobHistories>()
                .HasMany<Employees>(jobHist => jobHist.Employees)
                .WithOne(emp => emp.JobHistories);

            modelBuilder.Entity<Jobs>()
                .HasKey(jobs => jobs.Id);

            modelBuilder.Entity<Jobs>()
                .Property(jobs => jobs.Id)
                .HasMaxLength(10);

            modelBuilder.Entity<Jobs>()
                .Property(jobs => jobs.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Jobs>()
                .HasMany<Employees>(job => job.Employees)
                .WithOne(emp => emp.Jobs);
        }


    }
}
