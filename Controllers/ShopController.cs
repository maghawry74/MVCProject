using AutoMapper;
using Kotabko.Models;
using Kotabko.Repository.Interfaces;
using Kotabko.ViewsModels;
using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

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
        public IActionResult ShopIndex(int id, int pageNumber = 1)
        {
            ShopViewModel shopViewModel = new ShopViewModel();         
            shopViewModel.books = mapper.Map<List<MainBookVM>>(bookRepository.GetMainBooks(id, pageNumber));            
            shopViewModel.categoryVMs = mapper.Map<List<CategoryVM>>(categoryRepository.GetAll());
            shopViewModel.authorVMs = mapper.Map<List<AuthorVM>>(authorRepository.GetAll());           
            return View("ShopIndex", shopViewModel);
        }
        public IActionResult LoadBooks(int id, int pageNumber)
        {
            ShopViewModel shopViewModel = new ShopViewModel();
            shopViewModel.books = mapper.Map<List<MainBookVM>>(bookRepository.GetMainBooks(id, pageNumber));        
            return PartialView("MainShop",shopViewModel);
        }
       
        public IActionResult GetAuthor()
        {
            return View();
        }
       
       
    }
}
