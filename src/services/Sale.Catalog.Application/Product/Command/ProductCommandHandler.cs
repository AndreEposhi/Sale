using FluentValidation.Results;
using MediatR;
using Sale.Catalog.Domain.Product;
using Sale.Core.Messages;
using System;
using System.Threading;
using System.Threading.Tasks;
using ProductEntity = Sale.Catalog.Domain.Product.Product;

namespace Sale.Catalog.Api.Application.Product.Command
{
    public class ProductCommandHandler : CommandHandler, IRequestHandler<AddProductCommand, ValidationResult>
    {
        private readonly IProductRepository _productRepository;

        public ProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ValidationResult> Handle(AddProductCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
                return command.ValidationResult;

            var product = new ProductEntity(Guid.NewGuid(), command.Description, command.Amount);
            await _productRepository.AddAsync(product);

            return await Commit(_productRepository);
        }
    }
}