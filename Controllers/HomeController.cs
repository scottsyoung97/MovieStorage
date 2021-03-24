using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieStorage.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStorage.Controllers
{
    public class HomeController : Controller
    {
        private MovieDbContext _context { get; set; }

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, MovieDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Movies()
        {
            return View(_context.MovieInfo);
        }

        [HttpGet]
        public IActionResult Info()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Info(MovieInfo movieInfo)
        {
            if (ModelState.IsValid)
            {
                _context.MovieInfo.Add(movieInfo);
                _context.SaveChanges();
            }

            return View("Index");
        }

        [HttpPost]
        public IActionResult EditView (int movieId)
        {
            MovieInfo movie = _context.MovieInfo.SingleOrDefault(movie => movie.MovieId == movieId);
            return View("Edit", movie);
        }
        [HttpPost]
        public IActionResult Edit (MovieInfo movie)
        {

            if (ModelState.IsValid)
            {
                //update all of the different attributes
                var Movie = _context.MovieInfo.Single(x => x.MovieId == movie.MovieId);
                _context.Entry(Movie).Property(x => x.Category).CurrentValue = movie.Category;
                _context.Entry(Movie).Property(x => x.Title).CurrentValue = movie.Title;
                _context.Entry(Movie).Property(x => x.Year).CurrentValue = movie.Year;
                _context.Entry(Movie).Property(x => x.Director).CurrentValue = movie.Director;
                _context.Entry(Movie).Property(x => x.Rating).CurrentValue = movie.Rating;
                _context.Entry(Movie).Property(x => x.Edited).CurrentValue = movie.Edited;
                _context.Entry(Movie).Property(x => x.LentTo).CurrentValue = movie.LentTo;
                _context.Entry(Movie).Property(x => x.Notes).CurrentValue = movie.Notes;
                _context.SaveChanges();

            }

            return View("Index");
        }
        [HttpPost]
        public IActionResult Delete (int MovieId)
        {
            MovieInfo movie = _context.MovieInfo.SingleOrDefault(movie => movie.MovieId == MovieId);

            if (ModelState.IsValid)
            {
                _context.MovieInfo.Remove(movie);
                _context.SaveChanges();

            }

            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
