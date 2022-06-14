using Sale.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sale.Core.Data
{
    public interface IRepository<T> : IUnitOfWork where T : Entity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
    }
}