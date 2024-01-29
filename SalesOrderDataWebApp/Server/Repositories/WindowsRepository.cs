using SalesOrderDataWebApp.Server.DB;
using SalesOrderDataWebApp.Server.Repositories.InterfaceImplementations;
using SalesOrderDataWebApp.Shared.Models;

namespace SalesOrderDataWebApp.Server.Services
{
    public class WindowsRepository : IWindowsRepository
    {
        private readonly DatabaseContext _context;
        public WindowsRepository(DatabaseContext context) 
        {
            _context = context;
        }

        public void AddWindow(Window newWindow)
        {
            try
            {
                _context.Windows.Add(newWindow);
                SaveChangesToDatabase();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while adding window. Message: {ex.Message}");
            }
        }

        public bool Exists(int id)
        {
            return _context.Windows.Any(w => w.Id == id);
        }

        public Window GetWindow(int id)
        {
            try
            {
                return _context.Windows.Where(w => w.Id == id).First();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while getting window with Id '{id}'. Message: {ex.Message}");
            }
        }

        public List<Window> GetWindowsForOrder(int orderId)
        {
            try
            {
                return _context.Windows.Where(w => w.OrderId == orderId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while getting windows with order Id '{orderId}'. Message: {ex.Message}");
            }
        }

        public void RemoveWindow(int id) 
        {
            try
            {
                Window window = GetWindow(id);
                _context.Windows.Remove(window);
                SaveChangesToDatabase();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while removing window with Id '{id}'. Message: {ex.Message}");
            }
        }

        public void UpdateWindow(Window updatedWindow)
        {
            try
            {
                Window existingWindow = GetWindow(updatedWindow.Id);
                existingWindow.WindowName = updatedWindow.WindowName;
                SaveChangesToDatabase();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while updating window with Id '{updatedWindow.Id}'. Message: {ex.Message}");
            }
        }

        private void SaveChangesToDatabase() 
        {
            _context.SaveChanges();
        }
    }
}
