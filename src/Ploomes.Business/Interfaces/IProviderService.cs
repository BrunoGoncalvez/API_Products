using Ploomes.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ploomes.Business.Interfaces
{
    public interface IProviderService : IDisposable
    {

        Task Add(Provider provider);

        Task Update(Provider provider);

        Task Remove(Guid id);

        Task UpdateAddress(Address address);

    }
}
