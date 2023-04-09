using Kotabko.DataAccess;
using Kotabko.Models;
using Microsoft.EntityFrameworkCore;

namespace Kotabko.Repository.Classes
{
	public class ShoppingCardRepository
	{


		private readonly ApplicationDbContext _db;

		public ShoppingCardRepository(ApplicationDbContext _db)
		{
			this._db = _db;
		}



		/// configure the service
		public static ShoppingCardRepository GetshoppingCard(IServiceProvider services)
		{
			// check if we have a session with that id or not
			ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
			var context = services.GetService<ApplicationDbContext>();
			string cardId = session.GetString("CardId") ?? Guid.NewGuid().ToString();

			session.SetString("CardId", cardId);
			return new ShoppingCardRepository(context) { ShoppingCardId = cardId };

		}


		public string ShoppingCardId { get; set; }
		public List<ShoppingCardItem> ShoppingCardItems { get; set; }

		//fn to add item to card
		public void AdditemToCard(Book item)
		{
			var shoppingcarditem = _db.shoppingCardItems.FirstOrDefault(a => a.Book.Id == item.Id &&
			a.ShoppingCardId == ShoppingCardId
			);
			//if we do not have this item in our shoppingcard
			if (shoppingcarditem == null)
			{
				shoppingcarditem = new ShoppingCardItem()
				{
					ShoppingCardId = ShoppingCardId,
					Book = item,
					Amount = 1
				};
				_db.shoppingCardItems.Add(shoppingcarditem);

			}
			else
			{
				// the item already exist in the shopping card
				shoppingcarditem.Amount++;
			}
			_db.SaveChanges();
		}


		//fn to remove item from card
		public void RempveitemFromCard(Book item)
		{
			var shoppingcarditem = _db.shoppingCardItems.FirstOrDefault(a => a.Book.Id == item.Id &&
			a.ShoppingCardId == ShoppingCardId
			);
			//if we do not have this item in our shoppingcard
			if (shoppingcarditem != null)
			{
				if (shoppingcarditem.Amount > 1)
				{
					shoppingcarditem.Amount--;
				}
				else
				{
					// if it is the only item in shopping card
					_db.shoppingCardItems.Remove(shoppingcarditem);
				}

			}
			_db.SaveChanges();
		}


		public List<ShoppingCardItem> GetShoppingCardItems()
		{
			return ShoppingCardItems ?? (ShoppingCardItems = _db.shoppingCardItems.Where(a => a.ShoppingCardId == ShoppingCardId).
				Include(n => n.Book).ToList()
				);
		}

		//this is the to
		public double GetTotal()
		{
			var total = _db.shoppingCardItems.Where(a => a.ShoppingCardId == ShoppingCardId).Select(n => n.Book.Price * n.Amount).Sum();
			return total;
		}

		public async Task ClearShoppingCardAsync()
		{
			var items = await _db.shoppingCardItems.Where(a => a.ShoppingCardId == ShoppingCardId).
				ToListAsync();
			_db.shoppingCardItems.RemoveRange(items);
			await _db.SaveChangesAsync();
			
		}




    }
}
