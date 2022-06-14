using FluentValidation.Results;
using Sale.Core.Data;
using System.Threading.Tasks;

namespace Sale.Core.Messages
{
    public abstract class CommandHandler
    {
        protected ValidationResult ValidationResult = new();

        protected void AddError(string error)
            => ValidationResult.Errors.Add(new ValidationFailure(string.Empty, error));

        protected async Task<ValidationResult> Commit(IUnitOfWork unitOfWork)
        {
            if (!await unitOfWork.Commit())
                AddError("An error occurred while persisting to the database");

            return ValidationResult;
        }
    }
}