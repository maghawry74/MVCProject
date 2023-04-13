using Kotabko.Models;
using Kotabko.Repository.Classes;
using Kotabko.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kotabko.Controllers
{
    [Authorize(Roles ="Admin")]
    public class CategoryController : Controller
    {
        ICategoryRepository CategoryRepository;
        public CategoryController(ICategoryRepository _CategoryRepository)
        {
            CategoryRepository= _CategoryRepository;
        }
        public IActionResult Index()
        {
            return View(CategoryRepository.GetAll());
        }
        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Category category)
        {
            if(ModelState.IsValid) 
            {
                CategoryRepository.Add(category);
                return RedirectToAction("Index");
            }
            return View(category);
            
        }
        public IActionResult Delete(int id)
        {
           var result= CategoryRepository.Find(c=>c.Id== id);
            return View(result);
        }
        public IActionResult FinalDelete(int id)
        {
           bool result= CategoryRepository.Delete(c=>c.Id== id);
            if(result==true)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("NotFound");
            }
        }
        public IActionResult Edit(int id)
        {
            return View(CategoryRepository.Find(c => c.Id == id));
                
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            CategoryRepository.Update(category);
            return RedirectToAction("Index");

        }
    }
}
