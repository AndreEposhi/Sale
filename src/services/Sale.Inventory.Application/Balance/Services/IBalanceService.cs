using FluentValidation.Results;
using Sale.Inventory.Application.Balance.Command;
using System.Threading.Tasks;

namespace Sale.Inventory.Application.Balance.Services
{
    public interface IBalanceService
    {
        Task<ValidationResult> AddBalance(AddBalanceCommand command);
        Task<ValidationResult> UpdateBalance(UpdateBalanceCommand command);
    }
}