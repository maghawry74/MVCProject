using System.ComponentModel.DataAnnotations;

namespace Kotabko.Models;

public class Author
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public string Image { get; set; }
    public virtual ICollection<Book>? Books { get; set; }
}
