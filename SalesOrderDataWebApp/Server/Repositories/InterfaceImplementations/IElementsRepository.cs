using SalesOrderDataWebApp.Shared.Models;

namespace SalesOrderDataWebApp.Server.Repositories.InterfaceImplementations
{
    public interface IElementsRepository
    {
        void AddElement(Element newElement);
        void RemoveElement(int id);
        void UpdateElement(Element updatedElement);
        Element GetElement(int id);
        bool Exists(int id);
        List<Element> GetElementsForWindow(int windowId);
    }
}
