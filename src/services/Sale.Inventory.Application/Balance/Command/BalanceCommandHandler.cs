using FluentValidation.Results;
using MediatR;
using Sale.Inventory.Domain.Balance;
using System;
using System.Threading;
using System.Threading.Tasks;
using BalanceEntity = Sale.Inventory.Domain.Balance.Balance;

namespace Sale.Inventory.Application.Balance.Command
{
    public class BalanceCommandHandler : Core.Messages.CommandHandler,
        IRequestHandler<AddBalanceCommand, ValidationResult>,
        IRequestHandler<UpdateBalanceCommand, ValidationResult>
    {
        private readonly IBalanceRepository _balanceRepository;

        public BalanceCommandHandler(IBalanceRepository balanceRepository)
        {
            _balanceRepository = balanceRepository;
        }

        public async Task<ValidationResult> Handle(AddBalanceCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
                return command.ValidationResult;

            var balanceExist = await _balanceRepository.GetBalanceByProductId(command.ProductId);

            if (balanceExist is not null)
            {
                AddError("Product already balance");
                return ValidationResult;
            }

            var balance = new BalanceEntity(Guid.NewGuid(), command.ProductId, command.Quantity);
            await _balanceRepository.AddAsync(balance);

            return await Commit(_balanceRepository);
        }

        public async Task<ValidationResult> Handle(UpdateBalanceCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
                return command.ValidationResult;

            var balanceExist = await _balanceRepository.GetBalanceByProductId(command.ProductId);

            if (balanceExist is null)
            {
                AddError("Product is not found");
                return ValidationResult;
            }

            balanceExist.UpdateQuantity(command.Quantity);

            await _balanceRepository.UpdateAsync(balanceExist);

            return await Commit(_balanceRepository);
        }
    }
}