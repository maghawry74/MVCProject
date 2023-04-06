using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Kotabko.Models
{
	public class OrderItem
	{
		[Key]
		public int Id { get; set; }
		public int Amount { get; set; }
		public double Price { get; set; }
		[ForeignKey("Book")]
		public int BookId{ get; set; }
		[ForeignKey("Order")]
		public int OrderId { get; set; }
		public virtual Book Book { get; set; }
		public virtual Order Order { get; set; }
	}
}
