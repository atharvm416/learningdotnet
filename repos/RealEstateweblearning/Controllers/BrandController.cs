using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstateweblearning.Data;
using RealEstateweblearning.Models;
using RealEstateweblearning.Repositories;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace RealEstateweblearning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class BrandController : ControllerBase
    {
        private readonly IGenericRepository<Brand> _brandRepo;

        public BrandController(IGenericRepository<Brand> brandRepo)
        {
            _brandRepo = brandRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
     int pageNumber = 1,
     int pageSize = 10,
     decimal? minPrice = null,
     decimal? maxPrice = null)
        {
            var query = _brandRepo.Query(); // Exposes IQueryable<Brand>

            // Filtering
            if (minPrice.HasValue)
                query = query.Where(b => b.Price >= minPrice.Value);

            if (maxPrice.HasValue)
                query = query.Where(b => b.Price <= maxPrice.Value);

            // Total count before pagination
            var totalCount = await query.CountAsync();

            // Pagination
            var brands = await query
            .OrderBy(b => b.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();


            var response = new
            {
                totalCount,
                totalPages = (int)Math.Ceiling(totalCount / (double)pageSize),
                pageNumber,
                pageSize,
                data = brands
            };

            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> Create(Brand brand)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _brandRepo.AddAsync(brand);
            await _brandRepo.SaveAsync();
            return CreatedAtAction(nameof(GetAll), new { id = brand.Id }, brand);
        }


            //What is ModelState?
            //ModelState is a property that holds the results of model binding and validation.

            //ASP.NET Core automatically validates incoming request models(like your Brand object) using:

            //Data annotations(e.g., [Required], [StringLength], etc.)

            //Binding errors(e.g., type mismatches)

            //So if anything is invalid, ModelState.IsValid becomes false.
    }
}
