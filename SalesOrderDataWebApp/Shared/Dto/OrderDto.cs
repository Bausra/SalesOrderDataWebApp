
using System.ComponentModel.DataAnnotations;

namespace SalesOrderDataWebApp.Shared.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Buyer Name")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "{0} must be between {2} and {1} characters in length!")]
        public string BuyerName { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "{0} must contain only letters!")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "{0} must contain {1} characters in length!")]
        public string State { get; set; }
    }
}
