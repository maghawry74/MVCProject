using AutoMapper;
using Kotabko.Repository.Interfaces;
using Kotabko.ViewsModels;
using Microsoft.AspNetCore.Mvc;

namespace Kotabko.Controllers
{
    public class ShopController : Controller
    {
        private readonly IBookRepository bookRepository;
        private readonly IAuthorRepository authorRepository;
        private readonly ICategoryRepository categoryRepository;

        public IMapper mapper { get; }

        public ShopController(IBookRepository bookRepository, IMapper mapper, IAuthorRepository authorRepository, ICategoryRepository categoryRepository)
        {
            this.bookRepository = bookRepository;
            this.mapper = mapper;
            this.authorRepository = authorRepository;
            this.categoryRepository = categoryRepository;
        }
        public IActionResult ShopIndex(string category,string author ,[FromRouteAttribute] int id)
        {
            ShopViewModel shopViewModel = new ShopViewModel();
           
            if (category == null && author == null)
            {
                shopViewModel.books = mapper.Map<List<MainBookVM>>(bookRepository.GetAll());
                
            }
            else if(author != null && category == null )
            {
                shopViewModel.books = mapper.Map<List<MainBookVM>>(bookRepository.SearchingByAuthor(author));
                
            }
            else if(category != null && author == null)
            {
                shopViewModel.books = mapper.Map<List<MainBookVM>>(bookRepository.SearchingByCategories(category));
                
            }
            else
            {
                shopViewModel.books = mapper.Map<List<MainBookVM>>(bookRepository.SearchingByAuthorAndCategory(category,author));
                
            }
          
            shopViewModel.categoryVMs = mapper.Map<List<CategoryVM>>(categoryRepository.GetAll());
            shopViewModel.authorVMs = mapper.Map<List<AuthorVM>>(authorRepository.GetAll());
            shopViewModel.id = id;
            return View("ShopIndex", shopViewModel);
        }
        public IActionResult NextShop(List<MainBookVM> books)
        {
           
            return View(books);
        }
        public IActionResult GetAuthor()
        {
            return View();
        }
    }
}
