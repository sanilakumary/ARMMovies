
namespace ARM.Movies.Common.Models
{
    public class MovieUserRating
    {        
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public double Rating { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual User User { get; set; }
    }
}
