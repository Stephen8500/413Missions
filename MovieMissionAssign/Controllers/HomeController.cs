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

        //Index view
        public IActionResult Index()
        {
            return View();
        }

        //mypodcasts view
        public IActionResult MyPodcasts()
        {
            return View();
        }

        //get method to reach addmovie form
        [HttpGet]
        public IActionResult AddMovieForm()
        {
            return View();
        }
        
        //post method for saving form data to db
        [HttpPost]
        public IActionResult AddMovieForm(MovieForm mf)
        {
            //doesn't save to db if inputs invalid, returns confirmation page after saving if they are valid
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                MovieContext.Add(mf);
                MovieContext.SaveChanges();

                return View("Confirmation", mf);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
