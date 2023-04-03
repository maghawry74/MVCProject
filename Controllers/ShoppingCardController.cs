using Kotabko.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Kotabko.Controllers
{
    public class ShoppingCardController : Controller
    {
        private IShoppingcardRepository shoppingcardRepository;

        public ShoppingCardController(IShoppingcardRepository shoppingcardRepository)
        {
            this.shoppingcardRepository = shoppingcardRepository;   
        }
        public IActionResult Index()
        {
            return View();
        }

    }
}
