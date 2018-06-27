using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KnikLandscaping.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using KnikLandscaping.ViewModels;

namespace KnikLandscaping.Controllers
{
    public class HomeController : Controller
    {
        private IConfiguration _config;
        private KinkLandscapingContext _context;
        private ILogger<HomeController> _logger;

        public HomeController(IConfiguration config, KinkLandscapingContext context,
            ILogger<HomeController> logger)
        {
            _config = config;
            _context = context;
            _logger = logger;
        }
        public IActionResult Index()
        {
            try
            {
                var data = _context.Testimonials.ToList(); // query the database
                var vm = new TestimonialsViewModel();

                vm.testimonials = data;
                return View(data);
            }
            catch (Exception e)
            {
                //log exception
                _logger.LogError($"Failed to get modules: {e.Message}");
                return Redirect("/error");
            }
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
            try
            {
                var data = _context.Testimonials.ToList(); // query the database
                return View(data);
            }
            catch (Exception e)
            {
                //log exception
                _logger.LogError($"Failed to get modules: {e.Message}");
                return Redirect("/error");
            }
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
