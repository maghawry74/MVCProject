using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Kotabko.Models;

public class Book
{
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    public int AuthorId { get; set; }
    [Required]
    public string Image { get; set; }
    [Required]
    public string Description { get; set; }
    public float Price { get; set; }
    public float Rate { get; set; }
    [DefaultValue(true)]
    public bool IsAvaiable { get; set; }
    public int CategoryId { get; set; }
    public virtual Category? Category { get; set; }
    public virtual Author? Author { get; set; }
    public virtual ICollection<Order>? Orders { get; set; }
}
