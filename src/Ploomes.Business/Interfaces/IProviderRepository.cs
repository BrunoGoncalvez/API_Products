using Ploomes.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ploomes.Business.Interfaces
{
    public interface IProviderRepository : IRepository<Provider>
    {

        Task<Provider> GetProviderWithAddress(Guid id);
        Task<Provider> GetProviderWithProductsAndAddress(Guid id);

    }
}
