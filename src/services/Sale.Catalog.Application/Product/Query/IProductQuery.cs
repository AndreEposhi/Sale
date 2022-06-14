using System.Collections.Generic;
using System.Threading.Tasks;
using ProductEntity = Sale.Catalog.Domain.Product.Product;

namespace Sale.Catalog.Application.Product.Query
{
    public interface IProductQuery
    {
        Task<IEnumerable<ProductEntity>> GetAllAsync();
    }
}