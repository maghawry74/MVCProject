using Kotabko.Models;

namespace Kotabko.Repository.Interfaces
{
    public interface IBookRepository:IRepository<Book>
    {
        public IEnumerable<Book> SearchingByCategories(string category);
        public IEnumerable<Book> SearchingByAuthor(string author);
        public IEnumerable<Book> SearchingByAuthorAndCategory(string category,string author);
    }
}
