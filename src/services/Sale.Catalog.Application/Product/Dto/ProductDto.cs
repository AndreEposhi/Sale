using System;

namespace Sale.Catalog.Application.Product.Dto
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
    }
}