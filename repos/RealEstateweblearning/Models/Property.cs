using System.ComponentModel.DataAnnotations;

namespace RealEstateweblearning.Models
{
    public class Property
    {
        public int Id { get; set; }

        [Required]
        public string Address { get; set; } = string.Empty;

        [Range(1, 99999999)]
        public decimal Price { get; set; }

        public int AgencyId { get; set; }
    }
}
