using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Kotabko.Models;

namespace Kotabko.ViewsModels
{
    public class BookViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [DisplayName("Author")]
        public int AuthorId { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string Description { get; set; }
        public float Price { get; set; }
        [Range(0,5,ErrorMessage ="Rate must be between 0 and 5")]
        public float Rate { get; set; }
        [DefaultValue(true)]
        [DisplayName("IsAvailable")]
        public bool IsAvaiable { get; set; }
        [DisplayName("Category")]
        public int CategoryId { get; set; }
       public List<Category>? Categories { get; set; }
       public List<Author>? Authors { get; set; }
    }
}
