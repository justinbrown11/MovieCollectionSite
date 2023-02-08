using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollection.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {

        }

        public DbSet<NewMovieModel> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<NewMovieModel>().HasData(
                new NewMovieModel
                {
                    MovieId = 1,
                    Title = "The Dark Knight",
                    Category = "Action",
                    Year = 2008,
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = "Amazing"
                },
                new NewMovieModel
                {
                    MovieId = 2,
                    Title = "Interstellar",
                    Category = "Action",
                    Year = 2014,
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = "So amazing"
                },
                new NewMovieModel
                {
                    MovieId = 3,
                    Title = "The Prestige",
                    Category = "Psychological Thriller",
                    Year = 2006,
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = "Magical"
                }
            );
        }
    }
}
