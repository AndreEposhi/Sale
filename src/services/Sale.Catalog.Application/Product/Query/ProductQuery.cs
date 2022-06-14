using Sale.Catalog.Domain.Product;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProductEntity = Sale.Catalog.Domain.Product.Product;

namespace Sale.Catalog.Application.Product.Query
{
    public class ProductQuery : IProductQuery
    {
        private readonly IProductRepository _productRepository;

        public ProductQuery(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductEntity>> GetAllAsync()
            => await _productRepository.GetAllAsync();
    }
}