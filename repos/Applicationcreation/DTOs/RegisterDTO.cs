using System.ComponentModel.DataAnnotations;

namespace Applicationcreation.DTOs
{
    public class RegisterDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
