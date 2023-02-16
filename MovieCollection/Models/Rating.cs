using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollection.Models
{
    public class Rating
    {
        [Key]
        [Required]
        public int RatingId { get; set; }
        [Required]
        public string RatingDescription { get; set; }
    }
}
