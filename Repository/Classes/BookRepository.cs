using Kotabko.DataAccess;
using Kotabko.Models;
using Kotabko.Repository.Interfaces;
using Kotabko.ViewsModels;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;
using System.Linq.Expressions;
using static System.Reflection.Metadata.BlobBuilder;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Kotabko.Repository.Classes
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _db;
        public BookRepository(ApplicationDbContext _db)
        {
            this._db = _db;
            
        }

        public Book Add(Book entity)
        {
            _db.Add(entity);
            _db.SaveChanges();
            return entity;
        }

        public bool Delete(Expression<Func<Book, bool>> filter)
        {
            try
            {
                Book bk = _db.books.FirstOrDefault(filter);
                if (bk != null)
                {
                    _db.books.Remove(bk);
                    _db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch 
            {

                return false;
            }
        }

        public Book? Find(Expression<Func<Book, bool>> filter)
        {
            Book bk = _db.books.Include(b => b.Category).Include(b => b.Author).FirstOrDefault(filter);
            return bk;
        }

        public IEnumerable<Book> GetAll( )
        {
            IEnumerable<Book> books = _db.books.Include(b => b.Category).Include(b => b.Author).ToList();
            return books;

        }
              

        public bool Update(Book entity)
        {
            try
            {
                _db.books.Update(entity);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public IEnumerable<Book> GetMainBooks(int id, int pageNumber)
        {
            IEnumerable<Book> books = _db.books.Include(b => b.Category).Include(b => b.Author)
            .Where(b => b.CategoryId == id || id == 0)
            .ToList()
            .Skip((pageNumber - 1) * 6)
            .Take(6);
            return books;
        }

        public IEnumerable<Book> GetBooksAuthor(int id)
        {
            IEnumerable<Book> books = _db.books.Include(b => b.Author).Where(a=>a.AuthorId == id).ToList();
            return books;
        }
    }
}
