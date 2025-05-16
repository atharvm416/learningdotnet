using System;
using System.Collections.Generic;

namespace coresimulation.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Sku { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? ShortDescription { get; set; }

    public decimal Price { get; set; }

    public decimal? CostPrice { get; set; }

    public decimal? SpecialPrice { get; set; }

    public int? QuantityInStock { get; set; }

    public int? MinStockThreshold { get; set; }

    public decimal? Weight { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsFeatured { get; set; }

    public DateTime? DateAdded { get; set; }

    public DateTime? DateModified { get; set; }

    public int? ManufacturerId { get; set; }

    public string? MetaTitle { get; set; }

    public string? MetaKeywords { get; set; }

    public string? MetaDescription { get; set; }

    public string? Barcode { get; set; }

    public bool? IsDownloadable { get; set; }

    public string? DownloadUrl { get; set; }

    public bool? HasVariants { get; set; }

    public decimal? Rating { get; set; }

    public string? MainImageUrl { get; set; }

    public string? ImageAltText { get; set; }

    public virtual Manufacturer? Manufacturer { get; set; }
}
