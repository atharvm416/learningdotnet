using System.ComponentModel.DataAnnotations;

namespace RealEstateweblearning.Models
{
    public class Agency
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string Location { get; set; } = string.Empty;
    }
}
