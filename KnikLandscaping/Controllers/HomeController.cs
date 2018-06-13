using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KnikLandscaping.Models;
using Microsoft.Extensions.Configuration;

namespace KnikLandscaping.Controllers
{
    public class HomeController : Controller
    {
        private IConfiguration _config;

        private KinkLandscapingContext _context;

        public HomeController(IConfiguration config, KinkLandscapingContext context)
        {
            _config = config;
            _context = context;
        }
        public IActionResult Index()
        {
            //var data = _context.Testimonials.ToList(); // query the database
            //return View(data);
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Testimonials()
        {
            ViewData["Message"] = "Testimonials";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
