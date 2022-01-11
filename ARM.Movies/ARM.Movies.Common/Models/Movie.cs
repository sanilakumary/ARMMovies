using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ARM.Movies.Common.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; }        
        public int YearOfRelease { get; set; }        
        public int RunningTime { get; set; }               
        [Required]
        //TODO: For simplicity keeping the Genre as a string for now. Ideally we should have a master table for Genre and have it's id referred here 
        [StringLength(50)]        
        public string Genre { get; set; } 

        public virtual ICollection<MovieUserRating> MovieUserRatings { get; set; }
    }
}
