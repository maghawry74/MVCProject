using Kotabko.DataAccess;
using Kotabko.Models;
using Kotabko.Repository.Interfaces;
using System.Linq.Expressions;

namespace Kotabko.Repository.Classes
{
    public class OrderRepository :IOrderRepository
    {
        public ApplicationDbContext Db { get; }
        public OrderRepository(ApplicationDbContext Db)
        {
            this.Db = Db;
        }
        public IEnumerable<Order> GetAll()
        {
            return Db.orders.ToList();
        }
        public Order Add(Order order)
        {
            Db.orders.Add(order);
            Db?.SaveChanges();
            return order;
        }

        public bool Delete(Expression<Func<Order, bool>> filter)
        {
            try
            {
                Order? order = Db?.orders?.Find(filter);
                if (order == null) return false;
                Db?.orders.Remove(order);
                Db?.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Order? Find(Expression<Func<Order, bool>> order)
        {
            return Db?.orders.Find(order);
        }

        
        public bool Update(Order order)
        {
            try
            {
                Db?.orders.Update(order);
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
