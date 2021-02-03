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
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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
            return View(TempStorage.MovieInf);
        }

        [HttpGet]
        public IActionResult Info()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Info(MovieInfo movieInfo)
        {
            TempStorage.AddMovie(movieInfo);
            return View("Index", movieInfo);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
