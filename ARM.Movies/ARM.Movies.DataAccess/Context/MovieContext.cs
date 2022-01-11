using ARM.Movies.Common.Interfaces;
using ARM.Movies.Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ARM.Movies.DataAccess.Context
{
    public class MovieContext : DbContext, IMovieContext
    {
        public MovieContext(DbContextOptions<MovieContext> options)
            : base(options) { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<MovieUserRating> MovieUserRatings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieUserRating>()
                .HasKey(m => new { m.MovieId, m.UserId });
            
            //seed data
            int numOfMovies = 10;
            int numOfUsers = 10;
            modelBuilder.Entity<Movie>()
                .HasData(PopulateMovies(numOfMovies));
            modelBuilder.Entity<User>()
               .HasData(PopulateUsers(numOfUsers));
            modelBuilder.Entity<MovieUserRating>()
               .HasData(PopulateMovieUserRatings(numOfMovies, numOfUsers ));
        }

        private List<Movie> PopulateMovies(int numOfMovies)
        {
            var movies = new List<Movie>();            
            for(int i = 1; i <= numOfMovies; i++)
            {
                var movie = new Movie
                {
                    Id = i,
                    Title = $"Movie{i}",
                    YearOfRelease = new Random().Next(2000, 2022),
                    Genre = i % 2 > 0 ? "Comedy" : "Drama",
                    RunningTime = new Random().Next(50, 200)
                };

                movies.Add(movie);
            }

            return movies;            
        }

        private List<User> PopulateUsers(int numOfUsers)
        {
            var users = new List<User>();
            for (int i = 1; i <= numOfUsers; i++)
            {
                var user = new User
                {
                    Id = i,
                    Name = $"user{i}"                    
                };

                users.Add(user);
            }

            return users;
        }

        private List<MovieUserRating> PopulateMovieUserRatings(int numOfMovies, int numOfUsers)
        {
            var ratings = new List<MovieUserRating>();
            for (int i = 1; i <= numOfMovies; i++)
            {
                for (int j = 1; j <= numOfUsers; j++)
                {
                    var rating = new MovieUserRating
                    {
                        MovieId = i,
                        UserId = j,
                        Rating = new Random().Next(1, 5)
                    };
                    ratings.Add(rating);
                }
            }

            return ratings;
        }
    }
}
