using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Ploomes.API.ViewModels;
using Ploomes.Business.Interfaces;
using Ploomes.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ploomes.API.Controllers
{
    [Route("api/[controller]")]
    public class ProvidersController : MainController
    {

        private readonly IProviderRepository _providerRepository;
        private readonly IProviderService _providerService;
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public ProvidersController(IProviderRepository providerRepository, IProviderService providerService,
                                    IAddressRepository addressRepository, IMapper mapper)
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

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProviderViewModel>> GetById(Guid id)
        {
            var provider = await GetProviderWithProductsAndAddress(id);
            if (provider == null) return NotFound();
            return Ok(provider);
        }


        [HttpPost]
        public async Task<ActionResult<ProviderViewModel>> Create(ProviderViewModel providerViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();
            var provider = _mapper.Map<Provider>(providerViewModel);
            var result = await _providerService.Add(provider);

            if (!result) return BadRequest();
            return Ok(provider);
        }


        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ProviderViewModel>> Update(Guid id, ProviderViewModel providerViewModel)
        {
            if (id != providerViewModel.Id) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            var provider = _mapper.Map<Provider>(providerViewModel);
            var result = await _providerService.Update(provider);
            if (!result) return BadRequest();
            return Ok(provider);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ProviderViewModel>> Delete(Guid id)
        {
            var provider = await GetProviderWithAddress(id);
            if (provider == null) return NotFound();
            await _addressRepository.Remove(provider.Address.Id);
            var result = await _providerService.Remove(id);
            if (!result) return BadRequest();
            return Ok(provider);
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
