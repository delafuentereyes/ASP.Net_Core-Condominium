using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Proyecto_BD2.Models;
using System.Diagnostics;

namespace Proyecto_BD2.Controllers
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
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("userSession")))
            {
                ViewBag.User = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("userSession"));

                return View();
            }
            else
            {
                ViewBag.Error = new ErrorHandler()
                {
                    Title = "You must need to login to access this page",
                    ErrorMessage = "Please login",
                    Path = "/Login"
                };

                return View("ErrorHandler");
            }
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}