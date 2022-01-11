using ARM.Movies.Common.Models;
using System.Collections.Generic;

namespace ARM.Movies.Common.Interfaces
{   
    public interface IMovieRepository
    {
        /// <summary>
        /// Get a list of movies based on title, year of release and genre
        /// </summary>
        /// <param name="title"></param>
        /// <param name="yearOfRelease"></param>
        /// <param name="genre"></param>
        /// <returns>List of movies</returns>
        IEnumerable<MovieModel> GetMovies(string title = null, int? yearOfRelease = null, string genre = null);

        /// <summary>
        /// Get top movies based on total user rating
        /// </summary>
        /// <param name="numberOfMovies">Number of top movies to show, defaults to 5 movies</param>
        /// <returns>List of movies</returns>
        IEnumerable<MovieModel> GetTopMovies(int numberOfMovies);

        /// <summary>
        /// Get top movies based on a certain user’s rating
        /// </summary>
        /// <param name="user">Rating given by the user</param>
        /// <param name="numberOfMovies">Number of top movies to show, defaults to 5 movies</param>
        /// <returns>List of movies</returns>
        IEnumerable<MovieModel> GetTopMoviesByUser(string user, int numberOfMovies);

        /// <summary>
        /// Check whether a movie exists or not
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool MovieExists(int id);

        /// <summary>
        /// Check whether a user exists or not
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool UserExists(int id);

        /// <summary>
        /// Update movie rating
        /// </summary>
        /// <param name="movieUserRating"></param>
        void UpdateRating(MovieUserRating movieUserRating);
    }
}