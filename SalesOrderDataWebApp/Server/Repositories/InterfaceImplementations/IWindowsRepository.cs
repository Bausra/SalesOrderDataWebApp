using SalesOrderDataWebApp.Shared.Models;

namespace SalesOrderDataWebApp.Server.Repositories.InterfaceImplementations
{
    public interface IWindowsRepository
    {
        void AddWindow(Window newWindow);
        void RemoveWindow(int id);
        void UpdateWindow(Window updatedWindow);
        Window GetWindow(int id);
        bool Exists(int id);
        List<Window> GetWindowsForOrder(int orderId);
    }
}
