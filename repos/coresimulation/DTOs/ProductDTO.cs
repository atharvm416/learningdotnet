using System.ComponentModel.DataAnnotations;

namespace coresimulation.DTOs
{// ProductDTOs.cs
    public class ProductDto
    {
        public int Id { get; set; }
        public string Sku { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public decimal? SpecialPrice { get; set; }
        public string? MainImageUrl { get; set; }
        public string? ManufacturerName { get; set; }
        public bool? IsFeatured { get; set; }

        public ManufacturerDto? Manufacturer { get; set; }
    }

    public class ProductCreateDto
    {
        public string Sku { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? MainImageUrl { get; set; }
        public int? ManufacturerId { get; set; }
    }


    public class ProductUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [StringLength(100)]
        public string? Name { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [Range(0.01, 100000)]
        public decimal? Price { get; set; }

        public string? MainImageUrl { get; set; }
        public bool? IsFeatured { get; set; }
    }
}
