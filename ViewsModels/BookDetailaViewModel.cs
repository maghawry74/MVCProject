using Kotabko.Models;

namespace Kotabko.ViewsModels
{
    public class BookDetailaViewModel
    {
        public MainBookVM book { get; set; }
        public AuthorVM authorVM { get; set; }
        public CategoryVM categoryVM { get; set; }
    }
}
