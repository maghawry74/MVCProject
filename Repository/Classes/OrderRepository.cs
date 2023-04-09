using Kotabko.DataAccess;
using Kotabko.Models;
using Kotabko.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Order>> GetOrderbyUserIdAsync(string userId)
        {
            var orders = await Db.orders.Include(a => a.OrderItems).ThenInclude(b => b.Book).Where(n => n.UserId == userId).ToListAsync();
            return orders;
        }

        public async Task StoreOrderAsync(List<ShoppingCardItem> items, string UserId)
        {
            var order = new Order()
            {
                UserId = UserId,
 

            };
            await Db.orders.AddAsync(order);
            await Db.SaveChangesAsync();

            foreach (var item in items)
            {
                var orderitem = new OrderItem
                {
                    Amount = item.Amount,
                    BookId = item.Book.Id,
                    OrderId = order.Id,
                    Price = item.Book.Price

                };
                await Db.orderItems.AddAsync(orderitem);
            }
            await Db.SaveChangesAsync();
        }



    }
}
