using Microsoft.AspNetCore.Mvc;

namespace CookAlongAcademy.Controllers
{
    public class SubmissionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
