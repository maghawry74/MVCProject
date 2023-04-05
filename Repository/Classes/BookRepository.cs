using Kotabko.DataAccess;
using Kotabko.Models;
using Kotabko.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

        public IEnumerable<Book> GetAll()
        {
            IEnumerable<Book> bks = _db.books.Include(b=>b.Category).Include(b=>b.Author).ToList();
            return bks;

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
    }
}
