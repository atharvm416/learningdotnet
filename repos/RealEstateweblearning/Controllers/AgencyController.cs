using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstateweblearning.Data;
using RealEstateweblearning.Models;

namespace RealEstateweblearning.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgencyController : ControllerBase
    {
     private readonly RealEstateDbContext _context;

    public AgencyController(RealEstateDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_context.Agencies.ToList());
    }

    [HttpPost]
    public IActionResult Create(Agency agency)
    {
        _context.Agencies.Add(agency);
        _context.SaveChanges();
        return Ok(agency);
    }
}
}
