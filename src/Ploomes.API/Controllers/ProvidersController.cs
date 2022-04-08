using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ploomes.API.Extensions;
using Ploomes.API.ViewModels;
using Ploomes.Business.Interfaces;
using Ploomes.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ploomes.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ProvidersController : MainController
    {

        private readonly IProviderRepository _providerRepository;
        private readonly IProviderService _providerService;
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public ProvidersController(IProviderRepository providerRepository, IProviderService providerService,
                                    IAddressRepository addressRepository, INotifier notifier, IMapper mapper) : base(notifier)
        {
            _providerRepository = providerRepository;
            _addressRepository = addressRepository;
            _providerService = providerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProviderViewModel>> GetAll()
        {
            var providers = _mapper.Map<IEnumerable<ProviderViewModel>>(await _providerRepository.FindAll());
            return providers;
        }

        [AllowAnonymous]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProviderViewModel>> GetById(Guid id)
        {
            var provider = await GetProviderWithProductsAndAddress(id);
            if (provider == null) return NotFound();
            return CustomResponse(provider);
        }

        [ClaimsAuthorize("Provider","Create")]
        [HttpPost]
        public async Task<ActionResult<ProviderViewModel>> Create(ProviderViewModel providerViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            await _providerService.Add(_mapper.Map<Provider>(providerViewModel));
            return CustomResponse(providerViewModel);
        }

        [ClaimsAuthorize("Provider", "Update")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ProviderViewModel>> Update(Guid id, ProviderViewModel providerViewModel)
        {
            if (id != providerViewModel.Id) return BadRequest();
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            await _providerService.Update(_mapper.Map<Provider>(providerViewModel));
            return CustomResponse(providerViewModel);
        }

        [ClaimsAuthorize("Provider", "Delete")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ProviderViewModel>> Delete(Guid id)
        {
            var providerViewModel = await GetProviderWithAddress(id);
            if (providerViewModel == null) return NotFound();;
            await _providerService.Remove(id);
            return CustomResponse();
        }

        [AllowAnonymous]
        [HttpGet("get-address/{id:guid}")]
        public async Task<AddressViewModel> GetAddressById(Guid id)
        {
            var addressViewModel = _mapper.Map<AddressViewModel>(await _addressRepository.FindById(id));
            return addressViewModel;
        }

        [ClaimsAuthorize("Provider", "Update")]
        [HttpPut("update-address/{id:guid}")]
        public async Task<IActionResult> UpdateAddress(Guid id, AddressViewModel addressViewModel)
        {
            if (id != addressViewModel.Id) return BadRequest();
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            await _providerService.UpdateAddress(_mapper.Map<Address>(addressViewModel));
            return CustomResponse(addressViewModel);

        }

        private async Task<ProviderViewModel> GetProviderWithProductsAndAddress(Guid id)
        {
            return _mapper.Map<ProviderViewModel>(await _providerRepository.GetProviderWithProductsAndAddress(id));
        }

        private async Task<ProviderViewModel> GetProviderWithAddress(Guid id)
        {
            return _mapper.Map<ProviderViewModel>(await _providerRepository.GetProviderWithAddress(id));
        }

    }
}
