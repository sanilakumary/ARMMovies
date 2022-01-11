using System;
using System.ComponentModel.DataAnnotations;

namespace ARM.Movies.Common.Models
{
    public class MovieUserRatingModel
    {
        [Required]
        public int MovieId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        [Range(1,5)]
        public double Rating { get; set; } 
    }
}
