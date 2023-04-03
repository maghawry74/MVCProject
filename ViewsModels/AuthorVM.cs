using System.ComponentModel.DataAnnotations;

namespace Kotabko.ViewsModels
{
    public class AuthorVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Image { get; set; }
    }
}
