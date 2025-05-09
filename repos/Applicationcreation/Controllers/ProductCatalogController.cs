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
    public class ProductCatalogController : ControllerBase
    {
        private readonly ApplicationcreationContext _context;

        public ProductCatalogController(ApplicationcreationContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                // If the model state is not valid, return a bad request with the validation errors.
                return BadRequest(new { message = "Validation failed", errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList() });
            }

            try
            {
                var product = new Product
                {
                    Sku = dto.Sku,
                    Name = dto.Name,
                    Description = dto.Description,
                    Price = dto.Price,
                    MainImageUrl = dto.MainImageUrl,
                    ManufacturerId = dto.ManufacturerId,
                    DateAdded = DateTime.UtcNow,
                    IsActive = true
                };

                _context.Products.Add(product);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Product created successfully", productId = product.Id });
            }
            catch (DbUpdateException ex)
            {
                // Return a detailed error message if the database update fails
                return StatusCode(500, new { message = "Database update failed", error = ex.Message });
            }
            catch (Exception ex)
            {
                // Catch any other general exceptions and return the message
                return StatusCode(500, new { message = "An unexpected error occurred", error = ex.Message });
            }
        }
    }

}
