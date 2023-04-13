using Kotabko.Models;

namespace Kotabko.ViewsModels
{
    public class AuthorDetailsVM
    {
        public int Id { get; set; }

        public string Name { get; set; }
       
        public string Description { get; set; }
      
        public string Image { get; set; }
        public virtual ICollection<Book>? Books { get; set; }
        public List<MainBookVM>? AurhorBooks { get; set; }
    }
}
