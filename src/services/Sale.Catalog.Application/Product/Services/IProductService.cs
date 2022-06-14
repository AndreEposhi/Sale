using FluentValidation.Results;
using Sale.Catalog.Api.Application.Product.Command;
using Sale.Catalog.Application.Product.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sale.Catalog.Application.Product.Services
{
    public interface IProductService
    {
        Task<ValidationResult> AddProduct(AddProductCommand command);
        Task<IEnumerable<ProductDto>> GetAll();
    }
}