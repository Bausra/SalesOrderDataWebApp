
namespace SalesOrderDataWebApp.Shared.Models
{
    public class Window
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string WindowName { get; set; }

        public int OrderId { get; set; }
        public Order? Order { get; set; }
    }
}
