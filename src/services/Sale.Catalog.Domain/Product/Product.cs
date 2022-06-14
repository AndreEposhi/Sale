using Sale.Core.DomainObjects;
using System;

namespace Sale.Catalog.Domain.Product
{
    public class Product : Entity, IAggregateRoot
    {
        public string Description { get; private set; }
        public decimal Amount { get; private set; }

        protected Product() { }
        public Product(Guid id, string description, decimal amount)
        {
            Id = id;
            Description = description;
            Amount = amount;
        }

        public void Update(Product product)
        {
            Description = product.Description;
            Amount = product.Amount;
        }
    }
}