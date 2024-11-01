using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatingApp.API.DTOs
{
    public class RegisterDto
    {
        [Required]
        [StringLength(32)]
        public required  string Username { get; set; }
        [Required]
        [StringLength(255)]
        [EmailAddress]
        public required string  Email { get; set; }
        [Required]
        public required string Password {get; set;}
    }
}