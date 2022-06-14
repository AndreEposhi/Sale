using Sale.Order.Domain.Order;
using OrderEntity = Sale.Order.Domain.Order.Order;

namespace Sale.Order.Infra.Data.Order
{
    public class OrderRepository : Repository<OrderEntity>, IOrderRepository
    {
        public OrderRepository(OrderContext context) : base(context)
        {
        }
    }
}