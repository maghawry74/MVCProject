using Kotabko.Repository.Classes;
using Kotabko.Repository.Interfaces;
using Kotabko.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Kotabko.Controllers
{
	public class OrdersController : Controller
	{
		private readonly IBookRepository bookRepository;
		private readonly ShoppingCardRepository ShoppingCardRepository;

        public OrdersController(IBookRepository bookRepository, ShoppingCardRepository ShoppingCardRepository)
        {
			this.bookRepository = bookRepository;
			this.ShoppingCardRepository = ShoppingCardRepository;
            
        }
        public IActionResult Index()
		{
			return View();
		}


		public IActionResult ShoppingCard()
		{
			//this list will return a list of shopping card items
			var items = ShoppingCardRepository.GetShoppingCardItems();
			ShoppingCardRepository.ShoppingCardItems = items;
			var response = new ShoppingCardVM()
			{
				ShoppingCard = ShoppingCardRepository,
				ShoppingCardTotal = ShoppingCardRepository.GetTotal()

			};

			return View(response);
		}

		public IActionResult AddItemsToShoppingCard(int id)
		{
			var item = bookRepository.Find(a => a.Id == id);
			if (item != null)
			{
				ShoppingCardRepository.AdditemToCard(item);
				TempData["success"] = "Item Added To Shopping Card";

			}
			return RedirectToAction("ShoppingCard");
		}



		public IActionResult RemoveItemsfromShoppingCard(int id)
		{
			var item = bookRepository.Find(a => a.Id == id);
			if (item != null)
			{
				ShoppingCardRepository.RempveitemFromCard(item);
				TempData["success"] = "Item Removed From Shopping Card";

			}
			return RedirectToAction("ShoppingCard");
		}


	}
}
