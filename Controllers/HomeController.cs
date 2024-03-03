using Brooder.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic; // Necessary for using Lists

namespace Brooder.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            // Simply return the View without automatic redirection
            // You can decide in the View itself to show different content based on whether the user is signed in or not
            return View();
        }

        public async Task<IActionResult> Dashboard()
        {
            if (!_signInManager.IsSignedIn(User))
            {
                // If the user is not signed in, redirect them to the login page
                return RedirectToAction("Login", "User");
            }

            var currentUser = await _userManager.GetUserAsync(User) as ApplicationUser;
            if (currentUser == null)
            {
                _logger.LogError("User not found.");
                return RedirectToAction("Login", "User");
            }

            var model = new DashboardViewModel
            {
                User = currentUser,
                Recipes = await GetRecipesForUser(currentUser) // Ensure this method is implemented and returns meaningful data
            };

            return View(model);
        }

        private async Task<IEnumerable<Recipe>> GetRecipesForUser(ApplicationUser user)
        {
            // Placeholder implementation - replace with your actual data access logic
            return new List<Recipe>();
        }

        // Other actions remain unchanged
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
