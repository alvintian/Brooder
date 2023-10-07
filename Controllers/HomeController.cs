using CookAlongAcademy.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CookAlongAcademy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Dashboard()
        {
            var model = new DashboardViewModel
            {
                // Populate the model properties according to your needs
     //           User = /* get the current user */,
     //           Recipes = /* get the user's recipes */
        };
            if (model.User == null || model.Recipes == null)
            {
                // Handle null cases, log errors, or redirect as appropriate
            }
            model.Recipes = model.Recipes ?? new List<Recipe>();

            return View(model);  // Returns the Dashboard view with the model
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
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}