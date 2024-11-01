using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatingApp.API.Database.Entities
{
    [Table("users")]
    public class Users
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(32)]
        public required string Username { get; set; }
        [Required]
        [StringLength(255)]
        public required string  Email { get; set; }
        public byte[]? PasswordHash {get; set;}
        public byte[]? PasswordSalt { get; set; }
    }
}