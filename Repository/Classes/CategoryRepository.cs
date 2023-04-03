using Kotabko.DataAccess;
using Kotabko.Models;
using Kotabko.Repository.Interfaces;
using System.Linq.Expressions;

namespace Kotabko.Repository.Classes
{
    public class CategoryRepository : ICategoryRepository
    {
        ApplicationDbContext Db;
        public CategoryRepository(ApplicationDbContext Db)
        {
            this.Db = Db;
        }
        public Category Add(Category entity)
        {
            Db.categories.Add(entity);
            Db.SaveChanges();
            return entity;
        }

        public bool Delete(Expression<Func<Category, bool>> filter)
        {
            try
            {
                Category? categoery = Db?.categories?.Find(filter);
                if (categoery == null) return false;
                Db?.categories.Remove(categoery);
                Db?.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public Category? Find(Expression<Func<Category, bool>> filter)
        {
            return Db?.categories.Find(filter);
        }

        public IEnumerable<Category> GetAll()
        {
            return Db.categories.ToList();
        }

        public bool Update(Category entity)
        {
            try
            {
                Db?.categories.Update(entity);
                Db?.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
