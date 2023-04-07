using AutoMapper;
using Kotabko.Models;
using Kotabko.Repository.Interfaces;
using Kotabko.ViewsModels;
using Microsoft.AspNetCore.Mvc;

namespace Kotabko.Controllers
{
    
    public class BookController : Controller
    {
        IBookRepository bookRepository;
        ICategoryRepository categoryRepository;
        IAuthorRepository authorRepository;
        IMapper mapper;
        public BookController(IBookRepository _bookRepository,
            ICategoryRepository _categoryRepository, IAuthorRepository _authorRepository, IMapper _mapper)
        {
            bookRepository=_bookRepository;
            categoryRepository=_categoryRepository;
            authorRepository=_authorRepository;
            mapper = _mapper;
        }
        public IActionResult Index()
        {
            return View(bookRepository.GetAll());
        }
        public IActionResult New()
        {
            BookViewModel viewModel = new BookViewModel();
            viewModel.Categories = (List<Models.Category>?)categoryRepository.GetAll(); 
            viewModel.Authors= (List<Models.Author>?)authorRepository.GetAll();
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(BookViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                Book book = new Book();
                book = mapper.Map<Book>(viewModel);
                var SearchBook=bookRepository.Find(b=>b.Title.ToLower()==book.Title.ToLower());
                if(SearchBook!=null)
                {
                    ViewBag.message = "This Book Is Already Exsist";
                    return View(viewModel);
                }
                try
                {
                    bookRepository.Add(book);
                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("CategoryId", "Please Select Category");
                    ModelState.AddModelError("AuthorId", "Please Select Author");

                }
                    
                
            }
            viewModel.Categories = (List<Models.Category>?)categoryRepository.GetAll();
            viewModel.Authors = (List<Models.Author>?)authorRepository.GetAll();
            return View(viewModel);
        }
        public IActionResult Delete(int id)
        {
           Book book= bookRepository.Find(b => b.Id == id);
            if(book!=null)
            {
                return View(book);

            }
            return View("NotFound");
        }
        public IActionResult ConfiremDelete(int id)
        {
            bookRepository.Delete(b => b.Id == id);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
          var result=bookRepository.Find(b => b.Id == id);
           if(result!=null)
            {
                return View(result);
            }
            return View("NotFound");
        }
        public IActionResult Edit(int id)
        {
            Book book = bookRepository.Find(b => b.Id == id);
            if(book!=null)
            {
                var viewModel = mapper.Map<BookViewModel>(book);
                viewModel.Categories = (List<Models.Category>?)categoryRepository.GetAll();
                viewModel.Authors = (List<Models.Author>?)authorRepository.GetAll();

                return View(viewModel);
            }
            return View("NotFound");

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BookViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
               Book book=mapper.Map<Book>(viewModel);
               bookRepository.Update(book);
                return RedirectToAction("Index");
                
            }
            viewModel.Categories = (List<Models.Category>?)categoryRepository.GetAll();
            viewModel.Authors = (List<Models.Author>?)authorRepository.GetAll();
            return View(viewModel);
        }

    }
}
