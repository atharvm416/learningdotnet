using Applicationcreation.DTOs;
using Applicationcreation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Applicationcreation.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationcreationContext _context;

        public ProductController(ApplicationcreationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts()
        {
            var products = await _context.Products
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Sku = p.Sku,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    SpecialPrice = p.SpecialPrice,
                    MainImageUrl = p.MetaTitle, // Adjust if needed
                    ManufacturerName = p.Manufacturer != null ? p.Manufacturer.Name : null,
                    IsFeatured = p.IsFeatured
                })
                .ToListAsync();

            return Ok(products);
        }
    }
    }
