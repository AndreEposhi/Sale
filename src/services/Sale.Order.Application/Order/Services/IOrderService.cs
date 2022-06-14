using FluentValidation.Results;
using Sale.Order.Application.Order.Command;
using System.Threading.Tasks;

namespace Sale.Order.Application.Order.Services
{
    public interface IOrderService
    {
        Task<ValidationResult> AddOrder(AddOrderCommand command);
    }
}