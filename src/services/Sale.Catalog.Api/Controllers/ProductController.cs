using Microsoft.AspNetCore.Mvc;
using Sale.Catalog.Api.Application.Product.Command;
using Sale.Catalog.Application.Product.Services;
using Sale.Core.Controller;
using System.Threading.Tasks;

namespace Sale.Catalog.Api.Controllers
{
    [Route("api/products")]
    public class ProductController : MainController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddProduct([FromBody] AddProductCommand command)
            => CustomResponse(await _productService.AddProduct(command));

        [HttpGet("list")]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAll();

            return products == null ? NotFound() : CustomResponse(products);
        }
    }
}