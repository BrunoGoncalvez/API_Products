using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ploomes.API.ViewModels;
using Ploomes.Business.Interfaces;
using Ploomes.Business.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Ploomes.API.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    public class ProductsController : MainController
    {

        private readonly IProductRepository _productRepository;
        private readonly IProductService _productService;
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepository productRepository, IProductService productService,
                                    IAddressRepository addressRepository, INotifier notifier, IMapper mapper) : base(notifier)
        {
            _productRepository = productRepository;
            _addressRepository = addressRepository;
            _productService = productService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<ProductViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<ProductViewModel>>(await _productRepository.GetProductsWithProviders()); 
        }

        [AllowAnonymous]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProductViewModel>> GetById(Guid id)
        {
            var providerViewModel = await GetProduct(id);
            if (providerViewModel == null) return NotFound();
            return providerViewModel;
        }

        [HttpPost]
        public async Task<ActionResult<ProductViewModel>> Create(ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            var imgName = Guid.NewGuid() + "_" + productViewModel.Image;
            if (!UploadFile(productViewModel.ImageUpload, imgName)) return CustomResponse(productViewModel);

            productViewModel.Image = imgName;
            await _productService.Add(_mapper.Map<Product>(productViewModel));
            return CustomResponse(productViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Update(Guid id, ProductViewModel productViewModel)
        {
            if (id != productViewModel.Id) return BadRequest();

            var updateProduct = await GetProduct(id);
            productViewModel.Image = updateProduct.Image;

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if(productViewModel.ImageUpload != null)
            {
                var imgName = Guid.NewGuid() + "_" + productViewModel.Image;
                if(!UploadFile(productViewModel.ImageUpload, imgName))
                {
                    return CustomResponse(ModelState);
                }

                updateProduct.Image = imgName;
            }

            updateProduct.Name = productViewModel.Name;
            updateProduct.Description = productViewModel.Description;
            updateProduct.Price = productViewModel.Price;
            updateProduct.Active = productViewModel.Active;

            await _productService.Update(_mapper.Map<Product>(updateProduct));
            return CustomResponse(productViewModel);
        }


        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ProductViewModel>> Delete(Guid id)
        {
            var product = await GetProduct(id);
            if (product == null) return NotFound();
            await _productService.Remove(id);
            return CustomResponse(product);
        }




        private bool UploadFile(string file, string imgName)
        {            
            if(string.IsNullOrEmpty(file))
            {
                NotifyError("Enter a image!");
                return false;
            }

            var imageDataByteArray = Convert.FromBase64String(file);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", imgName);

            if (System.IO.File.Exists(filePath))
            {
                NotifyError("Image already registered.");
                return false;
            }

            System.IO.File.WriteAllBytes(filePath, imageDataByteArray);
            return true;
        }

        private async Task<ProductViewModel> GetProduct(Guid id)
        {
            return _mapper.Map<ProductViewModel>(await _productRepository.GetProductWithProvider(id));
        }

    }
}
