using SalesOrderDataWebApp.Server.Models;
using SalesOrderDataWebApp.Server.Repositories.InterfaceImplementations;
using SalesOrderDataWebApp.Shared.Models;

namespace SalesOrderDataWebApp.Server.Services
{
    public class ElementsRepository : IElementsRepository
    {
        private readonly DatabaseContext _context;
        public ElementsRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void AddElement(Element newElement)
        {
            try
            {
                _context.Elements.Add(newElement);
                SaveChangesToDatabase();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while adding element. Message: {ex.Message}");
            }        
        }

        public bool Exists(int id)
        {
            return _context.Elements.Any(e => e.Id == id);
        }

        public Element GetElement(int id)
        {
            try
            {
                return _context.Elements.Where(x => x.Id == id).First();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while getting element with Id '{id}'. Message: {ex.Message}");
            }
        }

        public List<Element> GetElementsForWindow(int windowId)
        {
            try
            {
                return _context.Elements.Where(x => x.WindowId == windowId).ToList();
            }
            catch(Exception ex)
            {
                throw new Exception($"Error while getting elements for window Id '{windowId}'. Message: {ex.Message}");
            }
        }

        public void RemoveElement(int id)
        {
            try
            {
                Element element = GetElement(id);
                _context.Elements.Remove(element);
                SaveChangesToDatabase();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while removing element with Id '{id}'. Message: {ex.Message}");
            }
        }

        public void UpdateElement(Element updatedElement)
        {
            try
            {
                Element existingElement = GetElement(updatedElement.Id);
                _context.Entry(existingElement).CurrentValues.SetValues(updatedElement);
                SaveChangesToDatabase();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while updating element with Id '{updatedElement.Id}'. Message: {ex.Message}");
            }
        }

        private void SaveChangesToDatabase()
        {
            _context.SaveChanges();
        }
    }
}
