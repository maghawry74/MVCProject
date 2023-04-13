using Kotabko.Models;

namespace Kotabko.Repository.Interfaces
{
    public interface IBookRepository:IRepository<Book>
    {
        public IEnumerable<Book> GetMainBooks(int category_Id, int pageNumber);
        public IEnumerable<Book> GetBooksAuthor(int id);

    }
}
