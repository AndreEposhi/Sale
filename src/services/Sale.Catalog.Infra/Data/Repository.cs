using Microsoft.EntityFrameworkCore;
using Sale.Core.Data;
using Sale.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sale.Catalog.Infra.Data
{
    //Todo André: Refatorar para reaproveitar - Pacote nuget do projeto Sale.Core
    public class Repository<T> : IRepository<T>, IUnitOfWork where T : Entity
    {
        private readonly CatalogContext _context;

        protected Repository(CatalogContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
            => await _context.AddAsync(entity);

        public async Task<bool> Commit()
            => await _context.SaveChangesAsync() > 0;

        public async Task<IEnumerable<T>> GetAllAsync()
            => await _context.Set<T>().AsNoTracking().ToListAsync();

        public async Task<T> GetByIdAsync(Guid id)
            => await _context.Set<T>().FirstOrDefaultAsync(f => f.Id == id);

        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            await Task.CompletedTask;
        }
    }
}