using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.DTOs
{
    public class LoginDto
    {
        [Required]
        [StringLength(32)]
        public required  string Username { get; set; }
        [Required]
        public required string Password {get; set;}

    }
}