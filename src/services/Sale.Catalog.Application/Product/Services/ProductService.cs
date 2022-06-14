using FluentValidation.Results;
using Sale.Catalog.Api.Application.Product.Command;
using Sale.Catalog.Application.Product.Dto;
using Sale.Catalog.Application.Product.Query;
using Sale.Core.Mediator;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sale.Catalog.Application.Product.Services
{
    public class ProductService : IProductService
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IProductQuery _productQuery;

        public ProductService(IMediatorHandler mediatorHandler, IProductQuery productQuery)
        {
            _mediatorHandler = mediatorHandler;
            _productQuery = productQuery;
        }

        public async Task<ValidationResult> AddProduct(AddProductCommand command) 
            => await _mediatorHandler.Send(command);

        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            var products = await _productQuery.GetAllAsync();

            if (!products.Any())
                return null;

            var productsDto = new List<ProductDto>();

            foreach (var product in products)
            {
                productsDto.Add(new ProductDto 
                {
                    Id = product.Id,
                    Description = product.Description,
                    Amount = product.Amount
                });
            }

            return productsDto;
        }
    }
}