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
            //Actor
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

            modelBuilder.Entity<Actor>()
                .Property(actor => actor.LastName)
                .HasMaxLength(20);

            modelBuilder.Entity<Actor>()
                .HasMany<MovieCast>(actor => actor.MovieCasts)
                .WithOne(movieCast => movieCast.Actor)
                .HasForeignKey(movieCast => movieCast.ActorId);

            //MovieCast
            modelBuilder.Entity<MovieCast>()
                .HasKey(movieCasr => new { movieCasr.ActorId, movieCasr.MovieId });

            //Movie
            modelBuilder.Entity<Movie>()
                .HasKey(movie => movie.Id);

            modelBuilder.Entity<Movie>()
                .Property(movie => movie.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Movie>()
                .Property(movie => movie.Title)
                .HasMaxLength(50);

            modelBuilder.Entity<Movie>()
                .Property(movie => movie.Lang)
                .HasMaxLength(50);

            modelBuilder.Entity<Movie>()
                .Property(movie => movie.RelCountry)
                .HasMaxLength(5);

            modelBuilder.Entity<Movie>()
                .HasMany<MovieCast>(movie => movie.MovieCasts)
                .WithOne(movieCast => movieCast.Movie)
                .HasForeignKey(movieCast => movieCast.MovieId);

            modelBuilder.Entity<Movie>()
                .HasMany<MovieGenres>(movie => movie.MovieGenres)
                .WithOne(movieGenres => movieGenres.Movies)
                .HasForeignKey(movieCast => movieCast.MovieId);

            modelBuilder.Entity<Movie>()
                .HasMany<Rating>(movie => movie.Ratings)
                .WithOne(rating => rating.Movie);

            modelBuilder.Entity<Movie>()
                .HasMany<MovieDirection>(movie => movie.MovieDirections)
                .WithOne(moviedirectiont => moviedirectiont.Movie);

            //MovieDirection
            modelBuilder.Entity<MovieDirection>()
                .HasKey(movieDirection => new { movieDirection.DirectorId, movieDirection.MovieId});

            modelBuilder.Entity<MovieDirection>()
                .HasOne<Director>(movieDirection => movieDirection.Director)
                .WithMany(director => director.MovieDirections)
                .HasForeignKey(movieDirection => movieDirection.MovieId);

            //Director
            modelBuilder.Entity<Director>()
                .HasKey(director => director.Id);

            modelBuilder.Entity<Director>()
                .Property(director => director.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Director>()
                .Property(movie => movie.FirstName)
                .HasMaxLength(20);

            modelBuilder.Entity<Director>()
                .Property(movie => movie.LasName)
                .HasMaxLength(20);

            modelBuilder.Entity<Director>()
                .HasMany<MovieDirection>(director => director.MovieDirections)
                .WithOne(moviedirectiont => moviedirectiont.Director)
                .HasForeignKey(movieDirection => movieDirection.DirectorId);

            //MovieGenres
            modelBuilder.Entity<MovieGenres>()
                .HasKey(movieGenres => new { movieGenres.MovieId, movieGenres.GenresId });

            //Genres
            modelBuilder.Entity<Genres>()
                .HasKey(genres => genres.Id);

            modelBuilder.Entity<Genres>()
                .Property(genres => genres.Title)
                .HasMaxLength(20);

            //Rating
            modelBuilder.Entity<Rating>()
                .HasKey(rating => new { rating.MovieId, rating.ReviewerId });

            //Reviewer
            modelBuilder.Entity<Reviewer>()
                .HasKey(reviewer => reviewer.Id);

            modelBuilder.Entity<Reviewer>()
                .Property(reviewer => reviewer.Name)
                .HasMaxLength(20);

            modelBuilder.Entity<Reviewer>()
                .HasMany<Rating>(director => director.Ratings)
                .WithOne(reviewer => reviewer.Reviewer)
                .HasForeignKey(reviewer => reviewer.ReviewerId);
        }
    }
}
