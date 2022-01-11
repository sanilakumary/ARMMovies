using ARM.Movies.Common.Interfaces;
using ARM.Movies.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ARM.Movies.DataAccess.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly IMovieContext _context;        

        public MovieRepository(IMovieContext context)
        {
            _context = context;            
        }

        public IEnumerable<MovieModel> GetMovies(string title = null, int? yearOfRelease = null, string genre = null)
        {
            var movies = from m in _context.Set<Movie>()
                        .Where(m => string.IsNullOrWhiteSpace(title) || m.Title.ToLower().Contains(title.ToLower()))
                        .Where(m => string.IsNullOrWhiteSpace(genre) || m.Genre.ToLower() == genre.ToLower())
                        .Where(m => yearOfRelease == null || m.YearOfRelease == yearOfRelease)
                         join mr in (
                            from r in _context.Set<MovieUserRating>()
                            group r by r.MovieId
                            into g                            
                            select new { g.Key, Rating = g.Average(g => g.Rating) })
                         on m.Id equals mr.Key
                         orderby m.Title
                         select new { m.Id, m.Title, m.RunningTime, m.YearOfRelease, m.Genre, mr.Rating };

            return movies?.Select(m => new MovieModel
            {
                Id = m.Id,
                Genre = m.Genre,
                RunningTime = m.RunningTime,
                Title = m.Title,
                YearOfRelease = m.YearOfRelease,
                AverageRating = RoundDigits(m.Rating)
            });
        }

        public IEnumerable<MovieModel> GetTopMovies(int numberOfMovies = 5)
        {
            var movies = from m in _context.Set<Movie>()
                         join mr in (
                            from r in _context.Set<MovieUserRating>()
                            group r by r.MovieId
                            into g
                            orderby g.Average(g => g.Rating) descending
                            select new { g.Key, Rating = g.Average(g => g.Rating) }).Take(numberOfMovies)
                         on m.Id equals mr.Key
                         orderby mr.Rating descending, m.Title
                         select new { m.Id, m.Title, m.RunningTime, m.YearOfRelease, m.Genre, mr.Rating };

            return movies?.Select(m => new MovieModel
            {
                Id = m.Id,
                Genre = m.Genre,
                RunningTime = m.RunningTime,
                Title = m.Title,
                YearOfRelease = m.YearOfRelease,
                AverageRating = RoundDigits(m.Rating)
            });
        }

        public IEnumerable<MovieModel> GetTopMoviesByUser(string user, int numberOfMovies)
        { 
            var movies = (from m in _context.Set<Movie>()
                          join mr in _context.Set<MovieUserRating>()                          
                          on m.Id equals mr.MovieId
                          join u in _context.Set<User>() on mr.UserId equals u.Id
                          where u.Name.ToLower() == user.ToLower()
                          orderby mr.Rating descending, m.Title
                          select new { m.Id, m.Title, m.RunningTime, m.YearOfRelease, m.Genre, mr.Rating })
                         .Take(numberOfMovies);

            return movies?.Select(m => new MovieModel
            {
                Id = m.Id,
                Genre = m.Genre,
                RunningTime = m.RunningTime,
                Title = m.Title,
                YearOfRelease = m.YearOfRelease,
                AverageRating = RoundDigits(m.Rating)
            });
        }

        public bool MovieExists(int id)
        {
            return _context.Movies.Find(id) != null;
        }

        public bool UserExists(int id)
        {
            return _context.Users.Find(id) != null;
        }

        public void UpdateRating(MovieUserRating movieUserRating)
        {
            var rating = _context.MovieUserRatings.Find(movieUserRating.MovieId, movieUserRating.UserId);

            if (rating == null)
            {
                _context.MovieUserRatings.Add(movieUserRating);
            }
            else
            {
                rating.Rating = movieUserRating.Rating;
            }

            _context.SaveChanges();
        }

        private static double RoundDigits(double value)
        { 
            return Math.Round(value * 2, MidpointRounding.AwayFromZero) / 2;
        }
    }
}