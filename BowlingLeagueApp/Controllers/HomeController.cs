using BowlingLeagueApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeagueApp.Controllers
{
    public class HomeController : Controller
    {
        private BowlersDbContext _context { get; set; }

        public HomeController(BowlersDbContext temp)
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            var bowlers = _context.Bowlers.ToList();

            return View(bowlers);
        }
        

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Teams = _context.Teams.ToList();

            return View("Form");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Teams = _context.Teams.ToList();

            var bowler = _context.Bowlers.Single(x => x.BowlerID == id);

            return View("Form", bowler);
        }

        [HttpPost]
        public IActionResult Form(Bowler b)
        {
            if (ModelState.IsValid)
            {
                if (b.BowlerID == 0)
                {
                    b.BowlerID = _context.Bowlers.ToList().LastOrDefault().BowlerID + 1;
                    _context.Bowlers.Add(b);
                }
                else
                {
                    _context.Bowlers.Update(b);
                }

                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Teams = _context.Teams.ToList();

                return View();
            }
        }

        [HttpPost]
        public IActionResult Delete(Bowler b)
        {
            _context.Bowlers.Remove(b);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
