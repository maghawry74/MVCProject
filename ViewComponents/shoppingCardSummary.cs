using Kotabko.Repository.Classes;
using Microsoft.AspNetCore.Mvc;

namespace Kotabko.ViewComponents
{
    [ViewComponent]
    public class shoppingCardSummary:ViewComponent
    {
        private readonly ShoppingCardRepository shoppingCardRepository;
        public shoppingCardSummary(ShoppingCardRepository shoppingCardRepository)
        {

            this.shoppingCardRepository = shoppingCardRepository;

        }


        public IViewComponentResult Invoke()
        {
            var items = shoppingCardRepository.GetShoppingCardItems();

            return View(items.Count);
        }

    }
}
