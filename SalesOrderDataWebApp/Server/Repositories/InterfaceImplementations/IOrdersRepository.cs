using SalesOrderDataWebApp.Shared.Models;

namespace SalesOrderDataWebApp.Server.Repositories.InterfaceImplementations
{
    public interface IOrdersRepository
    {
        void AddOrder(Order newOrder);
        void RemoveOrder(int id);
        void UpdateOrder(Order updatedOrder);
        Order GetOrder(int id);
        List<Order> GetAllOrders();
        bool Exists(int id);
    }
}
