using Sale.Core.Data;
using System;
using System.Threading.Tasks;

namespace Sale.Inventory.Domain.Balance
{
    public interface IBalanceRepository : IRepository<Balance>
    {
        Task<Balance> GetBalanceByProductId(Guid productId);
    }
}