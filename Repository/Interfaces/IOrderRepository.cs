using Kotabko.DataAccess;
using Kotabko.Models;

namespace Kotabko.Repository.Interfaces
{
    public interface IOrderRepository:IRepository<Order>
    {
        Task StoreOrderAsync(List<ShoppingCardItem> items, string UserId/*, string useremailAddress*/);

        Task<List<Order>> GetOrderbyUserIdAsync(string userId);


    }
}
