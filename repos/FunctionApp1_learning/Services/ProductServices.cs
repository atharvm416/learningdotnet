using FunctionApp1_learning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionApp1_learning.Services
{
    public class ProductServices
    {
        private readonly AppdbContext _dbContext;

        public ProductServices(AppdbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product> Addproduct(Product product)
        {
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
            return (product);
        }

        public async Task<Product> Updateproduct(Product product)
        {
            _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync();
            return (product);
        }
    }
}
