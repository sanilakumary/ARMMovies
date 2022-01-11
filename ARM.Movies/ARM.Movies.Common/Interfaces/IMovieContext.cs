using ARM.Movies.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace ARM.Movies.Common.Interfaces
{
    public interface IMovieContext
    {        
        DbSet<Movie> Movies { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<MovieUserRating> MovieUserRatings { get; set; }
        DbSet<T> Set<T>() where T : class;
        int SaveChanges();
    }
}