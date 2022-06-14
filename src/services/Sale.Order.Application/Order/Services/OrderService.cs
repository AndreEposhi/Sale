using FluentValidation.Results;
using Sale.Core.Mediator;
using Sale.Order.Application.Order.Command;
using System.Threading.Tasks;

namespace Sale.Order.Application.Order.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMediatorHandler _mediatorHandler;

        public OrderService(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        public async Task<ValidationResult> AddOrder(AddOrderCommand command)
            => await _mediatorHandler.Send(command);
    }
}