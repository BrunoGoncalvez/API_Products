using Ploomes.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ploomes.Business.Interfaces
{
    public interface IAddressRepository : IRepository<Address>
    {

        Task<Address> GetAddressByProvider(Guid providerId);

    }
}
