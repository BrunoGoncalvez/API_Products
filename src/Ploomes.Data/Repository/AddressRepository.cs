using Microsoft.EntityFrameworkCore;
using Ploomes.Business.Interfaces;
using Ploomes.Business.Models;
using Ploomes.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ploomes.Data.Repository
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {

        public AddressRepository(DataDbContext context) : base(context)
        {
        }

        public async Task<Address> GetAddressByProvider(Guid providerId)
        {
            return await _context.Address.AsNoTracking().FirstOrDefaultAsync(a => a.ProviderId == providerId);
        }
    }
}
