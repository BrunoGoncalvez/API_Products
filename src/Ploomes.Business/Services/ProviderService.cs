using Ploomes.Business.Interfaces;
using Ploomes.Business.Models;
using Ploomes.Business.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploomes.Business.Services
{
    public class ProviderService : BaseService, IProviderService
    {

        private readonly IProviderRepository _providerRepository;
        private readonly IAddressRepository _addressRepository;        

        public ProviderService(IProviderRepository providerRepository, IAddressRepository addressRepository, INotifier notifier)
            :base(notifier)
        {
            _providerRepository = providerRepository;
            _addressRepository = addressRepository;
        }

        public async Task<bool> Add(Provider provider)
        {
            if (!RunValidation(new ProviderValidation(), provider) || !RunValidation(new AddressValidation(), provider.Address))
            {
                return false;
            }

            if(_providerRepository.Search(p => p.Identification == provider.Identification).Result.Any())
            {
                Notify("Provider already registered.");
                return false;
            }

            await _providerRepository.Add(provider);
            return true;
        }

        public async Task<bool> Remove(Guid id)
        {
            if (_providerRepository.GetProviderWithProductsAndAddress(id).Result.Products.Any())
            {
                Notify("Provider has registered products.");
                return false;
            }

            await _providerRepository.Remove(id);
            return true;

        }

        public async Task<bool> Update(Provider provider)
        {
            if (!RunValidation(new ProviderValidation(), provider)) return false;
            if(_providerRepository.Search(p => p.Identification == provider.Identification && p.Id != provider.Id).Result.Any())
            {
                Notify("Provider already registered.");
                return false;
            }

            await _providerRepository.Update(provider);
            return true;
        }

        public async Task UpdateAddress(Address address)
        {
            if (!RunValidation(new AddressValidation(), address)) return;

            await _addressRepository.Update(address);
        }

        public void Dispose()
        {
            _providerRepository?.Dispose();
            _addressRepository?.Dispose();
        }

    }
}
