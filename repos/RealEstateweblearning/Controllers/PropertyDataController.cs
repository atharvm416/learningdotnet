using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstateweblearning.Data;
using RealEstateweblearning.Models;

namespace RealEstateweblearning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyDataController : ControllerBase
    {
        private readonly RealEstateDbContext _context;

        public PropertyDataController(RealEstateDbContext context)
        {
            _context = context;
        }

        [HttpGet("details")]
        public IActionResult GetProperty() {
            return Ok(_context.Properties.ToList());
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
        int pageNumber = 1,
        int pageSize = 10)
        {
            var query = _context.Properties.AsQueryable();


            var totalCount = await query.CountAsync();

            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var result = new
            {
                TotalCount = totalCount,
                PageSize = pageSize,
                PageNumber = pageNumber,
                Items = items
            };

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Property property)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _context.Properties.Add(property);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAll), new { id = property.Id }, property);
        }

    }
}
