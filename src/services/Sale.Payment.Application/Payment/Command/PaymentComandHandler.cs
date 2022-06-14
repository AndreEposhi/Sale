using FluentValidation.Results;
using MediatR;
using Sale.Core.MessageBus;
using Sale.Payment.Domain.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PaymentEntity = Sale.Payment.Domain.Payment.Payment;

namespace Sale.Payment.Application.Payment.Command
{
    public class PaymentComandHandler : Core.Messages.CommandHandler, IRequestHandler<AuthorizePaymentCommand, ValidationResult>
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMessageBus _bus;

        public PaymentComandHandler(IPaymentRepository paymentRepository, IMessageBus bus)
        {
            _paymentRepository = paymentRepository;
            _bus = bus;
        }

        public async Task<ValidationResult> Handle(AuthorizePaymentCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
                return command.ValidationResult;

            var payment = new PaymentEntity(Guid.NewGuid(), command.OrderId, command.Amount);
            payment.SetStatus(StatusPagamento.PaidOut);

            await _paymentRepository.AddAsync(payment);
            var result = await Commit(_paymentRepository);

            if (result.IsValid)
            {

            }

            return result;
        }
    }
}
