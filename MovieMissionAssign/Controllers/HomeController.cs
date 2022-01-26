using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieMissionAssign.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MovieMissionAssign.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private AddMovieContext MovieContext { get; set; }

        public HomeController(ILogger<HomeController> logger, AddMovieContext Movie)
        {
            _logger = logger;
            MovieContext = Movie;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyPodcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovieForm()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult AddMovieForm(MovieForm mf)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            MovieContext.Add(mf);
            MovieContext.SaveChanges();

            return View("Confirmation", mf);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
