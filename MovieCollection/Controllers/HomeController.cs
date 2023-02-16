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
        private MovieContext _movieContext { get; set; }

        public HomeController(MovieContext movie)
        {
            _movieContext = movie;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Movies()
        {
            var movies = _movieContext.Movies
                .Include(x => x.Category)
                .Include(x => x.Rating)
                .OrderBy(x => x.Title)
                .ToList();

            return View(movies);
        }

        [HttpGet]
        public IActionResult NewMovie()
        {
            ViewBag.Categories = _movieContext.Categories.ToList();
            ViewBag.Ratings = _movieContext.Ratings.ToList();
            ViewBag.Header = "Save a new movie";

            return View();
        }

        [HttpPost]
        public IActionResult NewMovie(NewMovieModel m)
        {
            if (ModelState.IsValid)
            {
                _movieContext.Add(m);
                _movieContext.SaveChanges();

                return View("Confirmation", m);
            }

            else
            {
                ViewBag.Categories = _movieContext.Categories.ToList();
                ViewBag.Ratings = _movieContext.Ratings.ToList();
                ViewBag.Header = "Save a new movie";

                return View(m);
            }
        }

        [HttpGet]
        public IActionResult EditMovie(int movieId)
        {
            var movie = _movieContext.Movies.Single(x => x.MovieId == movieId);

            ViewBag.Categories = _movieContext.Categories.ToList();
            ViewBag.Ratings = _movieContext.Ratings.ToList();
            ViewBag.Header = $"Edit {movie.Title}";

            return View("NewMovie", movie);
        }

        [HttpPost]
        public IActionResult EditMovie(NewMovieModel m)
        {
            if (ModelState.IsValid)
            {
                _movieContext.Update(m);
                _movieContext.SaveChanges();

                return RedirectToAction("Movies");
            }

            else
            {
                ViewBag.Categories = _movieContext.Categories.ToList();
                ViewBag.Ratings = _movieContext.Ratings.ToList();
                ViewBag.Header = $"Edit {m.Title}";

                return View("NewMovie", m);
            }
        }

        [HttpGet]
        public IActionResult DeleteMovie(int movieId)
        {
            var movie = _movieContext.Movies.Single(x => x.MovieId == movieId);

            return View(movie);
        }

        [HttpPost]
        public IActionResult DeleteMovie(NewMovieModel m)
        {
            _movieContext.Movies.Remove(m);
            _movieContext.SaveChanges();

            return RedirectToAction("Movies");
        }
    }
}
