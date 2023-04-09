using Kotabko.DataAccess;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Kotabko.Models;

public class Order
{
    public int Id { get; set; }
    [Required]
    public string UserId { get; set; }

    public virtual ApplicationUser? User { get; set; }
    [Required]
    [DefaultValue(false)]
    public bool Completed { get; set; }
    [Required]
    public DateTime CreatedAt { get; set; }
	public virtual List<OrderItem>? OrderItems { get; set; }
}
