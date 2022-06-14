using Sale.Core.DomainObjects;
using System;

namespace Sale.Payment.Domain.Payment
{
    public class Payment : Entity, IAggregateRoot
    {
        public Guid OrderId { get; private set; }
        public decimal Amount { get; private set; }
        public StatusPagamento Status { get; private set; }

        public Payment() { }
        public Payment(Guid id, Guid orderId, decimal amount)
        {
            Id = id;
            OrderId = orderId;
            Amount = amount;
        }

        public void SetStatus(StatusPagamento status)
            => Status = status;
    }
}