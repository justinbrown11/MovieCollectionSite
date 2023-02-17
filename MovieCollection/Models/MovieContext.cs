using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollection.Models
{
    /// <summary>
    /// Movie Database Context
    /// </summary>
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {

        }

        public DbSet<NewMovieModel> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            // Seed Ratings
            mb.Entity<Rating>().HasData(
                new Rating
                {
                    RatingId = 1,
                    RatingDescription = "G"
                },
                new Rating
                {
                    RatingId = 2,
                    RatingDescription = "PG"
                },
                new Rating
                {
                    RatingId = 3,
                    RatingDescription = "PG-13"
                },
                new Rating
                {
                    RatingId = 4,
                    RatingDescription = "R"
                }
            );

            // Seed Categories
            mb.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    CategoryName = "Action/Adventure"
                },
                new Category
                {
                    CategoryId = 2,
                    CategoryName = "Comedy"
                },
                new Category
                {
                    CategoryId = 3,
                    CategoryName = "Drama"
                },
                new Category
                {
                    CategoryId = 4,
                    CategoryName = "Family"
                },
                new Category
                {
                    CategoryId = 5,
                    CategoryName = "Horror/Suspense"
                },
                new Category
                {
                    CategoryId = 6,
                    CategoryName = "Miscellaneous"
                },
                new Category
                {
                    CategoryId = 7,
                    CategoryName = "Television"
                },
                new Category
                {
                    CategoryId = 8,
                    CategoryName = "VHS"
                }
            );

            // Seed Movies
            mb.Entity<NewMovieModel>().HasData(
                new NewMovieModel
                {
                    MovieId = 1,
                    Title = "The Dark Knight",
                    CategoryId = 1,
                    Year = 2008,
                    Director = "Christopher Nolan",
                    RatingId = 3,
                    Edited = false,
                    LentTo = "",
                    Notes = "Amazing"
                },
                new NewMovieModel
                {
                    MovieId = 2,
                    Title = "Interstellar",
                    CategoryId = 1,
                    Year = 2014,
                    Director = "Christopher Nolan",
                    RatingId = 3,
                    Edited = false,
                    LentTo = "",
                    Notes = "So amazing"
                },
                new NewMovieModel
                {
                    MovieId = 3,
                    Title = "Jaws",
                    CategoryId = 5,
                    Year = 1975,
                    Director = "Steven Spielberg",
                    RatingId = 2,
                    Edited = false,
                    LentTo = "",
                    Notes = "Terrifying"
                },
                new NewMovieModel
                {
                    MovieId = 4,
                    Title = "The Sound of Music",
                    CategoryId = 4,
                    Year = 1965,
                    Director = "Robert Wise",
                    RatingId = 1,
                    Edited = false,
                    LentTo = "",
                    Notes = "Garbage"
                }
            );
        }
    }
}
