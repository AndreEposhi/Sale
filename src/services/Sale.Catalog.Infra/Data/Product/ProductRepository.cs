using Sale.Catalog.Domain.Product;

namespace Sale.Catalog.Infra.Data.Product
{
    public class ProductRepository : Repository<Domain.Product.Product>, IProductRepository
    {
        private readonly CatalogContext _context;

        public ProductRepository(CatalogContext context) : base(context)
        {
            _context = context;
        }
    }
}