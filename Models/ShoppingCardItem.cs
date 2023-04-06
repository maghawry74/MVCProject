using System.ComponentModel.DataAnnotations;

namespace Kotabko.Models
{
	public class ShoppingCardItem
	{

		[Key]
		public int Id { get; set; }
		public Book Book { get; set; }
		public int Amount { get; set; }
		public string ShoppingCardId { get; set; }

	}
}
