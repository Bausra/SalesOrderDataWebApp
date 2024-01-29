using System.ComponentModel.DataAnnotations;

namespace SalesOrderDataWebApp.Shared.Dto
{
    public class WindowDto
    {
        public int Id { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "{0} must be between {1} and {2}.")]
        public int Quantity { get; set; }
        [Required]
        [Display(Name = "Window Name")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "{0} must be between {2} and {1} characters in length!")]
        public string WindowName { get; set; }

        public int OrderId { get; set; }
        public OrderDto? Order { get; set; }
    }
}
