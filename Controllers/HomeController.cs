using CookAlongAcademy.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic; // Make sure you include this if you're using Lists

namespace CookAlongAcademy.Controllers
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

        public async Task<IActionResult> Index()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Dashboard");
            }
            else
            {
                return RedirectToAction("Register", "User");
            }
        }

        public async Task<IActionResult> Dashboard()
        {
            if (!_signInManager.IsSignedIn(User))
            {
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
                User = currentUser, // currentUser is cast to ApplicationUser
                Recipes = await GetRecipesForUser(currentUser)
            };

            return View(model);
        }

        // Implement this method according to your data access logic
        private async Task<IEnumerable<Recipe>> GetRecipesForUser(ApplicationUser user)
        {
            // Your logic to fetch recipes for the given user
            // Example:
            // return await _recipeService.GetRecipesByUserId(user.Id);
            return new List<Recipe>(); // Placeholder return
        }



        // Add other actions like Privacy if necessary
        public IActionResult Privacy()
        {
            return View();
        }

        // Add error handling if necessary
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
