using Kotabko.DataAccess;
using Kotabko.Models;
using Kotabko.Repository.Interfaces;
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
                Book bk = _db.books.Find(filter);
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
            Book bk = _db.books.Find(filter);
            return bk;
        }

        public IEnumerable<Book> GetAll()
        {
            IEnumerable<Book> bks = _db.books.ToList();
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
