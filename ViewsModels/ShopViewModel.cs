using Kotabko.Models;

namespace Kotabko.ViewsModels
{
     public class ShopViewModel
    {
        public  List<MainBookVM>? books { get; set; }
        public List<AuthorVM>? authorVMs { get; set; }
        public List<CategoryVM>? categoryVMs { get; set; }
        
     }
}
