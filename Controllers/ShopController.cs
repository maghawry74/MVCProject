using Microsoft.AspNetCore.Mvc;

namespace Kotabko.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult ShopIndex()
        {
            return View("ShopIndex");
        }
    }
}
