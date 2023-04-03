using Kotabko.DataAccess;
using Kotabko.Models;
using Kotabko.Repository.Interfaces;

namespace Kotabko.Repository.Classes
{
    public class ShoppingcardRepository : IShoppingcardRepository
    {
        private readonly ApplicationDbContext _db;
        public ShoppingcardRepository(ApplicationDbContext _db)
        {
            this._db = _db;
        }
        public void Addtocard(int id)
        {
           Book bk = _db.books.Where(b=>b.Id==id).FirstOrDefault();  
           booklist.Add(bk);    
        }

        public void Removecard(int id)
        {
            Book bk = _db.books.Where(b => b.Id == id).FirstOrDefault();
            booklist.Remove(bk);
        }

        public List<Book> booklist { get; set; }
    }
}
