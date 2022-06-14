using FluentValidation.Results;
using MediatR;
using System.Text.Json.Serialization;

namespace Sale.Core.Messages
{
    public abstract class Command : IRequest<ValidationResult>
    {
        [JsonIgnore]
        public ValidationResult ValidationResult { get; set; }
        public Command()
        {
            ValidationResult = new ValidationResult();
        }

        public abstract bool IsValid();
    }
}