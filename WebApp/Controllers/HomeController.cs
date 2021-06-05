using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public class Vm
        {
            public string? Foo { get; set; }
            public string? Bar { get; set; }
        }
        public IActionResult Test()
        {
            ViewBag.loler = "here";
            var foobar = "Test";
            return View(foobar);
        }
        [HttpPost]
        public string Test( string? foo, int? id, string? far)
        {
            return $"Far is: '{far}' Foo is: '{foo ?? "null" }' id: {id?.ToString() ?? "null"} ModelState.IsValid: {ModelState.IsValid}";
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}