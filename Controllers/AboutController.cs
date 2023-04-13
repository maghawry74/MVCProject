using Microsoft.AspNetCore.Mvc;

namespace Kotabko.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult About()
        {
            return View();
        }
    }
}
