using System.ComponentModel.DataAnnotations;

namespace coresimulation.DTOs
{
    public class RegisterDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public string RoleId { get; set; }
    }
}
