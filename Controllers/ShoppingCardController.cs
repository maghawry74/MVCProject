using Kotabko.Repository.Classes;
using Kotabko.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Kotabko.Controllers
{
    public class ShoppingCardController : Controller
    {
        private ShoppingCardRepository shoppingcardRepository;

        public ShoppingCardController(ShoppingCardRepository shoppingcardRepository)
        {
            this.shoppingcardRepository = shoppingcardRepository;   
        }
        public IActionResult Index()
        {
            return View();
        }

    }
}
