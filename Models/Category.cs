using System.ComponentModel.DataAnnotations;

namespace Kotabko.Models;

public class Category
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string image { get; set; }
    public virtual ICollection<Book>? books { get; set; }
}
