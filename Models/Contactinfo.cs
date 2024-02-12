using System.ComponentModel.DataAnnotations;

namespace Easyway.Models
{
    public class Contactinfo
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name must be at most 100 characters")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Subject is required")]
        [StringLength(200, ErrorMessage = "Subject must be at most 200 characters")]
        public string? Subject { get; set; }
        [Required(ErrorMessage = "Message is required")]
        [StringLength(500, ErrorMessage = "Message must be at most 500 characters")]
        public string? Message { get; set; }
    }
}
