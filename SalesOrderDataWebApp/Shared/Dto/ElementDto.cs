
using SalesOrderDataWebApp.Shared.Models;
using System.ComponentModel.DataAnnotations;

namespace SalesOrderDataWebApp.Shared.Dto
{
    public class ElementDto
    {
        public int Id { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "{0} must be between {1} and {2}.")]
        public int ElementNo { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "{0} must be between {1} and {2}.")]
        public int Width { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "{0} must be between {1} and {2}.")]
        public int Height { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "{0} must be between {2} and {1} characters in length!")]
        public string ElementType { get; set; }

        public int WindowId { get; set; }
        public WindowDto? Window { get; set; }
    }
}
