using Microsoft.EntityFrameworkCore;
using Ploomes.Business.Interfaces;
using Ploomes.Business.Models;
using Ploomes.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploomes.Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {

        public ProductRepository(DataDbContext context) : base(context)
        {
        }

        public async Task<Product> GetProductWithProvider(Guid id)
        {
            return await _context.Products.AsNoTracking().Include(p => p.Provider).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProductsWithProviders()
        {
            var result = await _context.Products.AsNoTracking().Include(p => p.Provider).OrderBy(p => p.Name).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Product>> GetProductsByProvider(Guid providerId)
        {
            return await Search(p => p.Id == providerId);
        }
    }
}
