using FunctionApp1_learning.Models;
using Microsoft.EntityFrameworkCore;

namespace FunctionApp1_learning
{
    public class AppdbContext: DbContext
    {
        public AppdbContext(DbContextOptions<AppdbContext> options): base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
