using Kotabko.DataAccess;
using Kotabko.Models;
using Kotabko.Repository.Interfaces;
using System.Linq.Expressions;
using Kotabko.DataAccess;

namespace Kotabko.Repository.Classes
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext db;
        public AuthorRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public Author Add(Author entity)
        {
            db.authors.Add(entity);
            db.SaveChanges();
            return entity;
        }

        public bool Delete(Expression<Func<Author, bool>> filter)
        {
            try
            {
                Author? author = db.authors.FirstOrDefault(filter);
                if (author == null)
                    return false;
                db.authors.Remove(author);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Author? Find(Expression<Func<Author, bool>> filter)
        {
           return db.authors.FirstOrDefault(filter);
        }

        public IEnumerable<Author> GetAll()
        {
            return db.authors.ToList();
        }        
        public bool Update(Author entity)
        {
            try
            {               
                    db.authors.Update(entity);
                    db.SaveChanges();
                    return true;                
            }
            catch
            {
                return false;
            }
        }
        public IEnumerable<Author> GetAuthorBooks(int id)
        {
            return db.authors.Where(a=>a.Id == id).ToList();
        }

    }
}
