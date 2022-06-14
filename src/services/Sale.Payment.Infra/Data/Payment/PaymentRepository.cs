using Sale.Payment.Domain.Payment;
using PaymentEntity = Sale.Payment.Domain.Payment.Payment;

namespace Sale.Payment.Infra.Data.Payment
{
    public class PaymentRepository : Repository<PaymentEntity>, IPaymentRepository
    {
        public PaymentRepository(PaymentContext context) : base(context)
        { }
    }
}