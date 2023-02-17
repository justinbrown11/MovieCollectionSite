using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MovieCollection.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollection.Controllers
{
    public class HomeController : Controller
    {
        // Database context
        private MovieContext _movieContext { get; set; }

        public HomeController(MovieContext movie)
        {
            _movieContext = movie;
        }

        // Home page
        public IActionResult Index()
        {
            return View();
        }

        // My podcasts page
        public IActionResult Podcasts()
        {
            return View();
        }

        // Movies page
        [HttpGet]
        public IActionResult Movies()
        {
            // Grab all movies
            var movies = _movieContext.Movies
                .Include(x => x.Category)
                .Include(x => x.Rating)
                .OrderBy(x => x.Title)
                .ToList();

            return View(movies);
        }

        // Add new movie form page
        [HttpGet]
        public IActionResult NewMovie()
        {
            ViewBag.Categories = _movieContext.Categories.ToList();
            ViewBag.Ratings = _movieContext.Ratings.ToList();
            ViewBag.Header = "Save a new movie"; // To dynamically render the title (this view is used more than once)

            return View();
        }

        // New movie form submission
        [HttpPost]
        public IActionResult NewMovie(NewMovieModel m)
        {
            // Data is valid
            if (ModelState.IsValid)
            {
                _movieContext.Add(m);
                _movieContext.SaveChanges();

                return View("Confirmation", m); // Return confirmation page
            }

            // Data invalid, return back to form
            else
            {
                ViewBag.Categories = _movieContext.Categories.ToList();
                ViewBag.Ratings = _movieContext.Ratings.ToList();
                ViewBag.Header = "Save a new movie";

                return View(m);
            }
        }

        // Edit movie (renders back to NewMovie view)
        [HttpGet]
        public IActionResult EditMovie(int movieId)
        {
            // Grab the movie by id passed
            var movie = _movieContext.Movies.Single(x => x.MovieId == movieId);

            ViewBag.Categories = _movieContext.Categories.ToList();
            ViewBag.Ratings = _movieContext.Ratings.ToList();
            ViewBag.Header = $"Edit {movie.Title}"; // dynamic title since we are using the same view as above for NewMovie

            // Return NewMovie view with current movie selected
            return View("NewMovie", movie);
        }

        // Edit movie form submission
        [HttpPost]
        public IActionResult EditMovie(NewMovieModel m)
        {
            // If data is valid
            if (ModelState.IsValid)
            {
                _movieContext.Update(m);
                _movieContext.SaveChanges();

                return RedirectToAction("Movies"); // Redirect back to movies list
            }

            // Data invalid, return back to form
            else
            {
                ViewBag.Categories = _movieContext.Categories.ToList();
                ViewBag.Ratings = _movieContext.Ratings.ToList();
                ViewBag.Header = $"Edit {m.Title}";

                return View("NewMovie", m);
            }
        }

        // Delete movie confirmation page
        [HttpGet]
        public IActionResult DeleteMovie(int movieId)
        {
            // Grab selected movie
            var movie = _movieContext.Movies.Single(x => x.MovieId == movieId);

            return View(movie);
        }

        // Delete movie form submission
        [HttpPost]
        public IActionResult DeleteMovie(NewMovieModel m)
        {
            _movieContext.Movies.Remove(m);
            _movieContext.SaveChanges();

            // Redirect back to movies list
            return RedirectToAction("Movies");
        }
    }
}
