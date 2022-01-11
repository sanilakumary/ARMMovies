using ARM.Movies.Common.Interfaces;
using ARM.Movies.Common.Models;
using ARM.Movies.Logging;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ARM.Movies.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;        
        private readonly ILoggerManager _loggerManager;

        public MoviesController(IMovieRepository movieRepository, ILoggerManager loggerManager)
        {
            _movieRepository = movieRepository;
            _loggerManager = loggerManager;            
        }

        /// <summary>
        /// Gets a list of movies based on title, year of release and/or genre
        /// </summary>
        /// <param name="title">Title or partial title of the movie</param>
        /// <param name="yearOfRelease">Year of release</param>
        /// <param name="genre">Genre</param>
        /// <returns>List of movies</returns>
        [HttpGet]
        public IActionResult Get(string title = null, int? yearOfRelease = null, string genre = null)
        {
            if (string.IsNullOrWhiteSpace(title) && yearOfRelease == null && string.IsNullOrWhiteSpace(genre))
                return BadRequest("Please provide at least one parameter.");

            var movies = _movieRepository.GetMovies(title, yearOfRelease, genre);
            if (movies == null || !movies.Any())
                return NotFound("Not found");                

            return Ok(movies);
        }

        /// <summary>
        /// Get top movies based on total user rating
        /// </summary>
        /// <param name="numberOfTopMovies">Number of top movies to show, defaults to 5 movies</param>
        /// <returns>Lit of movies</returns>
        [HttpGet("TopMovies")]
        public IActionResult GetTopMovies(int numberOfTopMovies = 5)
        {
            var movies = _movieRepository.GetTopMovies(numberOfTopMovies);
            if (movies == null || !movies.Any())
                return NotFound("Not found");

            return Ok(movies);
        }

        /// <summary>
        /// Get top movies based on a certain user’s rating
        /// </summary>
        /// <param name="user">Rating given by the user</param>
        /// <param name="numberOfTopMovies">Number of top movies to show, default to 5 movies</param>
        /// <returns>List of movies</returns>
        [HttpGet("User/TopMovies")]
        public IActionResult GetTopMoviesByUser(string user, int numberOfTopMovies = 5)
        {
            if (string.IsNullOrWhiteSpace(user))
                return BadRequest("Please provide a user.");

            var movies = _movieRepository.GetTopMoviesByUser(user, numberOfTopMovies);
            if (movies == null || !movies.Any())
                return NotFound("Not found");

            return Ok(movies);
        }
        
        /// <summary>
        /// Give rating to a movie
        /// </summary>
        /// <param name="movieUserRatingModel"></param>
        /// <returns></returns>
        [HttpPost("RateMovie")]
        public IActionResult RateMovie([FromBody] MovieUserRatingModel movieUserRatingModel)
        {            
            if (!_movieRepository.MovieExists(movieUserRatingModel.MovieId))
                return NotFound("Movie Not found");
            
            if (!_movieRepository.UserExists(movieUserRatingModel.UserId))
                return NotFound("User Not found");

            _movieRepository.UpdateRating(
                new MovieUserRating {
                    MovieId = movieUserRatingModel.MovieId,
                    UserId = movieUserRatingModel.UserId,
                    Rating = movieUserRatingModel.Rating
                });
            
            return Ok("Rating updated");
        }
    }
}
