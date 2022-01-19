using Microsoft.AspNetCore.Mvc;
using Mission2Assign.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission2Assign.Controllers
{
    public class ProfileController : Controller
    {
        // route for index - main page
        public IActionResult Index()
        {
            return View();
        }

        // get for gradecalculator
        [HttpGet]
        public IActionResult GradeCalculator()
        {
            return View();
        }

        // post for gradecalculator
        [HttpPost]
        public IActionResult GradeCalculator(GradeCalculatorModel model)
        {
            return View();
        }
    }
}
