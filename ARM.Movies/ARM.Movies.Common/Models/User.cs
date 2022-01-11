using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ARM.Movies.Common.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }

        public virtual IEnumerable<MovieUserRating> Ratings { get; set; }
    }
}
