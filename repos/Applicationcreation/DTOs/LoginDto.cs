﻿using System.ComponentModel.DataAnnotations;

namespace Applicationcreation.DTOs
{
    public class LoginDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
