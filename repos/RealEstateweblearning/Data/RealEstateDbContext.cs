using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RealEstateweblearning.Models;

namespace RealEstateweblearning.Data
{
    public class RealEstateDbContext : DbContext
    {
        public RealEstateDbContext(DbContextOptions<RealEstateDbContext> options) : base(options) { }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Agency> Agencies { get; set; }
        public DbSet<Property> Properties { get; set; }
    }
}
