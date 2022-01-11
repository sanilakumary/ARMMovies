
namespace ARM.Movies.Common.Models
{
    public class MovieModel
    {
        public int Id { get; set; }        
        public string Title { get; set; }        
        public int YearOfRelease { get; set; }        
        public int RunningTime { get; set; }
        public string Genre { get; set; }
        public double AverageRating { get; set; }
    }
}
