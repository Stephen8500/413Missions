using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private AddMovieContext MovieContext { get; set; }

        public HomeController(AddMovieContext Movie)
        {
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
            //pass in categories for dropdown
            ViewBag.Categories = MovieContext.Categories.ToList();

            return View();
        }
        
        //post method for saving form data to db
        [HttpPost]
        public IActionResult AddMovieForm(MovieForm mf)
        {
            //doesn't save to db if inputs invalid, returns confirmation page after saving if they are valid
            if (!ModelState.IsValid)
            {
                //pass in categories for dropdown on reload
                ViewBag.Categories = MovieContext.Categories.ToList();

                return View();
            }
            else
            {
                MovieContext.Add(mf);
                MovieContext.SaveChanges();

                return View("Confirmation", mf);
            }
        }

        //list out movies using MovieList view
        public IActionResult MovieList()
        {
            //create list of movies to be passed in for viewing
            var movies = MovieContext.Movies
                .Include(x => x.Category)
                .ToList();

            return View(movies);
        }

        //edit view accessing
        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            //pass in categories for dropdown
            ViewBag.Categories = MovieContext.Categories.ToList();

            //get specific movie that user clicked on
            var movie = MovieContext.Movies
                .Single(x => x.MovieId == movieid);

            return View("AddMovieForm", movie);
        }

        //post method for edit view: should edit the movie info in db
        [HttpPost]
        public IActionResult Edit(MovieForm mf)
        {
            if (ModelState.IsValid)
            {
                //make changes in db
                MovieContext.Update(mf);
                MovieContext.SaveChanges();

                //return user to movielist page
                return RedirectToAction("MovieList");
            }
            else
            {
                ViewBag.Categories = MovieContext.Categories.ToList();

                return View("AddMovieForm", mf);
            }
            
        }

        //delete get route, for confirmation
        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            //find associated movie for referencing in view and passing to post
            var movie = MovieContext.Movies
                .Single(x => x.MovieId == movieid);

            return View(movie);
        }

        //post method for deleting a movie
        [HttpPost]
        public IActionResult Delete(MovieForm mf)
        {
            //make changes in db
            MovieContext.Remove(mf);
            MovieContext.SaveChanges();

            //return user to movielist page
            return RedirectToAction("MovieList");
        }
    }
}
