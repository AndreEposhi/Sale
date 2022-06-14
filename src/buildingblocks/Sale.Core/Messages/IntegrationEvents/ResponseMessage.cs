using FluentValidation.Results;
using System;

namespace Sale.Core.Messages.IntegrationEvents
{
    public class ResponseMessage
    {
        public Guid AggregateRootId { get; protected set; }
        public ValidationResult ValidationResult { get; set; }

        public ResponseMessage(ValidationResult validationResult)
        {
            ValidationResult = validationResult;
        }
    }
}