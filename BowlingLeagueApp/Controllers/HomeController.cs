﻿using BowlingLeagueApp.Models;
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

        public IActionResult Index(string team)
        {
            var bowlers = _context.Bowlers
                .Where(x => x.Team.TeamName == team || team == null)
                .ToList();

            return View(bowlers);
        }
        

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Teams = _context.Teams.ToList();
            ViewBag.Id = 0;

            return View("Form");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Teams = _context.Teams.ToList();

            var bowler = _context.Bowlers.Single(x => x.BowlerID == id);
            ViewBag.Id = bowler.BowlerID;

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
        public IActionResult Delete(int id)
        {
            var bowler = _context.Bowlers.Single(x => x.BowlerID == id);
            _context.Bowlers.Remove(bowler);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
