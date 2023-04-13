using Kotabko.DataAccess;
using Kotabko.Models;

namespace Kotabko.Repository.Interfaces
{
    public interface IAuthorRepository : IRepository<Author>
    {
        public IEnumerable<Author> GetAuthorBooks(int id);
    }
}
