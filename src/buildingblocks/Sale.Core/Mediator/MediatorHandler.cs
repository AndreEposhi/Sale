using FluentValidation.Results;
using MediatR;
using Sale.Core.Messages;
using System.Threading.Tasks;

namespace Sale.Core.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ValidationResult> Send<T>(T command) where T : Command 
            => await _mediator.Send(command);
    }
}