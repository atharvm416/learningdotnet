using System.ComponentModel.DataAnnotations;

namespace RealEstateweblearning.Models
{
    public class Brand
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(1, 1000000)]
        public decimal Price { get; set; }
    }
}
