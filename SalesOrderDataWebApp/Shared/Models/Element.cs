
namespace SalesOrderDataWebApp.Shared.Models
{
    public class Element
    {
        public int Id { get; set; }
        public int ElementNo { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string ElementType { get; set; }

        public int WindowId { get; set; }
        public Window? Window { get; set; }
    }
}
