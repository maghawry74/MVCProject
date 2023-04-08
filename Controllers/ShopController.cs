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
        public IActionResult ShopIndex(){
            
            ShopViewModel shopViewModel = new ShopViewModel();
            shopViewModel.books = mapper.Map<List<MainBookVM>>(bookRepository.GetAll()); 
            shopViewModel.categoryVMs = mapper.Map<List<CategoryVM>>(categoryRepository.GetAll()); 
            shopViewModel.authorVMs = mapper.Map<List<AuthorVM>>(authorRepository.GetAll());
            return View("ShopIndex", shopViewModel);
        }
        public IActionResult GetAuthor()
        {
            return View();
        }
    }
}
