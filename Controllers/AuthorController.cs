using Kotabko.Models;
using Kotabko.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Kotabko.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AuthorController : Controller
    {
        IAuthorRepository AuthorRepository;
        public AuthorController(IAuthorRepository _AuthorRepository)
        {
            AuthorRepository= _AuthorRepository;
        }
        public IActionResult Index()
        {
            
            return View("Index", AuthorRepository.GetAll());
        }
        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Author author) 
        { 
            if(ModelState.IsValid)
            {
                AuthorRepository.Add(author);
                return RedirectToAction("Index");
            }
            return View(author);
        }
        public IActionResult Delete(int id)
        {
            
            return View(AuthorRepository.Find(a => a.Id == id));
        }
        public IActionResult DeleteComfirm(int id)
        {
           bool result= AuthorRepository.Delete(a => a.Id == id);
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
            return View(AuthorRepository.Find(c=>c.Id== id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Author author)
        {
            if(ModelState.IsValid)
            {
                AuthorRepository.Update(author);
                return RedirectToAction("Index");
            }
            
            return View(author);
        }
    }
}
