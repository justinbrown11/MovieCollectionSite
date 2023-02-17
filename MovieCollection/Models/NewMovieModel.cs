using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollection.Models
{
    /// <summary>
    /// Movies
    /// </summary>
    public class NewMovieModel
    {
        [Key]
        [Required]
        public int MovieId { get; set; }

        [Required(ErrorMessage = "You must pick a category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [Required]
        public string Title { get; set; }

        [Required(ErrorMessage = "Year must be a valid year i.e. 2023")]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required(ErrorMessage = "You must select a rating")]
        public int RatingId { get; set; }
        public Rating Rating { get; set; }

        public bool Edited { get; set; }

        public string LentTo { get; set; }

        [StringLength(25)]
        public string Notes { get; set; }
    }
}
