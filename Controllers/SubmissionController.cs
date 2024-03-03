using Microsoft.AspNetCore.Mvc;

namespace Brooder.Controllers
{
    public class SubmissionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
