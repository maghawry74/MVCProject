using Kotabko.DataAccess;
using Kotabko.Repository.Interfaces;
using System.Linq.Expressions;

namespace Kotabko.Repository.Classes
{
    public class UserRepository : IUserRepository
    {
        public ApplicationDbContext Db { get; }
        public UserRepository(ApplicationDbContext Db)
        {
            this.Db = Db;
        }


        public ApplicationUser Add(ApplicationUser entity)
        {
            Db?.Users.Add(entity);
            Db?.SaveChanges();
            return entity;
        }

        public bool Delete(Expression<Func<ApplicationUser, bool>> filter)
        {
            try
            {
                ApplicationUser? user = Db?.Users?.Find(filter);
                if (user == null) return false;
                Db?.Users.Remove(user);
                Db?.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public ApplicationUser? Find(Expression<Func<ApplicationUser, bool>> filter)
        {
            return Db?.Users.Find(filter);
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            return Db.Users.ToList();
        }

        public bool Update(ApplicationUser entity)
        {
            try
            {
                Db?.Users.Update(entity);
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
