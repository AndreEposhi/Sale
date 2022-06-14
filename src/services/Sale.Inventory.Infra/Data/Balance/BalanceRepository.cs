using Microsoft.EntityFrameworkCore;
using Sale.Inventory.Domain.Balance;
using System;
using System.Threading.Tasks;
using BalanceEntity = Sale.Inventory.Domain.Balance.Balance;

namespace Sale.Inventory.Infra.Data.Balance
{
    public class BalanceRepository : Repository<BalanceEntity>, IBalanceRepository
    {
        private readonly InventoryContext _context;
        public BalanceRepository(InventoryContext context) : base(context)
        {
            _context = context;
        }

        public async Task<BalanceEntity> GetBalanceByProductId(Guid productId)
            => await _context.Balances.FirstOrDefaultAsync(p => p.ProductId == productId);
    }
}