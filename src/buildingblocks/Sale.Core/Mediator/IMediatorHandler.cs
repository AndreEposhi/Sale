using FluentValidation.Results;
using Sale.Core.Messages;
using System.Threading.Tasks;

namespace Sale.Core.Mediator
{
    public interface IMediatorHandler
    {
        Task<ValidationResult> Send<T>(T command) where T : Command;
    }
}