using FluentValidation.Results;
using Sale.Core.Mediator;
using Sale.Inventory.Application.Balance.Command;
using System.Threading.Tasks;

namespace Sale.Inventory.Application.Balance.Services
{
    public class BalanceService : IBalanceService
    {
        private readonly IMediatorHandler _mediatorHandler;

        public BalanceService(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        public async Task<ValidationResult> AddBalance(AddBalanceCommand command)
            => await _mediatorHandler.Send(command);

        public async Task<ValidationResult> UpdateBalance(UpdateBalanceCommand command)
            => await _mediatorHandler.Send(command);
    }
}