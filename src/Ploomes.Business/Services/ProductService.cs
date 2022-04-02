using Ploomes.Business.Interfaces;
using Ploomes.Business.Models;
using Ploomes.Business.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ploomes.Business.Services
{
    public class ProductService : BaseService, IProductService
    {

        private readonly IProductRepository _productRespository;

        public ProductService(IProductRepository productRepository, INotifier notifier)
            : base(notifier)
        {
            _productRespository = productRepository;
        }

        public async Task Add(Product product)
        {
            if (!RunValidation(new ProductValidation(), product)) return;
            await _productRespository.Add(product);
        }        

        public async Task Remove(Guid id)
        {
            await _productRespository.Remove(id);
        }

        public async Task Update(Product product)
        {
            if (!RunValidation(new ProductValidation(), product)) return;
            await _productRespository.Update(product);
        }

        public void Dispose()
        {
            _productRespository?.Dispose();
        }

    }
}
