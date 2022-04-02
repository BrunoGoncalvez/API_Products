using Microsoft.EntityFrameworkCore;
using Ploomes.Business.Interfaces;
using Ploomes.Business.Models;
using Ploomes.Data.Context;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Ploomes.Data.Repository
{
    public class ProviderRepository : Repository<Provider>, IProviderRepository
    {
        public ProviderRepository(DataDbContext context) : base(context)
        {
        }

        public async Task<Provider> GetProviderWithAddress(Guid id)
        {
            return await _context.Providers.AsNoTracking().Include(p => p.Address).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Provider> GetProviderWithProductsAndAddress(Guid id)
        {
            return await _context.Providers.AsNoTracking().Include(p => p.Products).Include(p => p.Address).FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
