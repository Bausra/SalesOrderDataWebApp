using SalesOrderDataWebApp.Server.Models;
using SalesOrderDataWebApp.Server.Repositories.InterfaceImplementations;
using SalesOrderDataWebApp.Shared.Models;

namespace SalesOrderDataWebApp.Server.Services
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly DatabaseContext _context;
        public OrdersRepository(DatabaseContext context) 
        {
            _context = context;
        }


        public void AddOrder(Order newOrder)
        {
            try
            {
                _context.Orders.Add(newOrder);
                SaveChangesToDatabase();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while adding order. Message: {ex.Message}");
            }
        }

        public bool Exists(int id)
        {
            return _context.Orders.Any(o => o.Id == id);
        }

        public List<Order> GetAllOrders()
        {
            try
            {
                return _context.Orders.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while getting orders. Message: {ex.Message}");
            }
        }

        public Order GetOrder(int id)
        {
            try
            {
                return _context.Orders.Where(x => x.Id == id).First();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while getting order with Id '{id}'. Message: {ex.Message}");
            }
        }

        public void RemoveOrder(int id) 
        {
            try
            {
                Order order = GetOrder(id);
                _context.Orders.Remove(order);
                SaveChangesToDatabase();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while removing order with Id '{id}'. Message: {ex.Message}");
            }
        }

        public void UpdateOrder(Order updatedOrder) 
        {
            try
            {
                Order existingOrder = GetOrder(updatedOrder.Id);
                existingOrder.BuyerName = updatedOrder.BuyerName;
                existingOrder.State = updatedOrder.State;
                SaveChangesToDatabase();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while updating order with Id '{updatedOrder.Id}'. Message: {ex.Message}");
            }
        }

        private void SaveChangesToDatabase()
        {
            _context.SaveChanges();
        }
    }   
}
