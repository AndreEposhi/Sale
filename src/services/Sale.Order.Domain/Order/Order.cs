using Sale.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sale.Order.Domain.Order
{
    public class Order : Entity, IAggregateRoot
    {
        private readonly List<OrderItem> _items = new();
        public int Code { get; private set; }
        public decimal Amount { get; private set; }

        public IReadOnlyCollection<OrderItem> Items => _items;

        public Order()
        {
        }

        public Order(Guid id, int code)
        {
            Id = id;
            Code = code;
        }

        public void AddItem(OrderItem item)
            => _items.Add(item);

        public void CalculateAmount()
        {
            if (!_items.Any())
                return;

            Amount += _items.Sum(s => s.Quantity * s.UnitaryValue);
        }
    }
}