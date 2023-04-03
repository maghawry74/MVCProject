using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Kotabko.Models;

public class Category
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public virtual ICollection<Book>? books { get; set; }
}
