using AutoMapper;
using Kotabko.Repository.Interfaces;
using Kotabko.ViewsModels;

using Microsoft.AspNetCore.Authorization;


using Microsoft.AspNetCore.Mvc;

namespace Kotabko.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookRepository bookRepository;

        public HomeController(IBookRepository bookRepository, IMapper mapper)
        {
            this.bookRepository = bookRepository;
            Mapper = mapper;
        }


        public IMapper Mapper { get; }


        

        public IActionResult Index()
        {
            var BooksVM = Mapper.Map<List<MainBookVM>>(bookRepository.GetAll());
            return View(BooksVM);
        }

    }
}