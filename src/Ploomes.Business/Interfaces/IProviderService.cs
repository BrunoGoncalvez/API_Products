using Ploomes.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ploomes.Business.Interfaces
{
    public interface IProviderService : IDisposable
    {

        Task<bool> Add(Provider provider);

        Task<bool> Update(Provider provider);

        Task<bool> Remove(Guid id);

        Task UpdateAddress(Address address);

    }
}
