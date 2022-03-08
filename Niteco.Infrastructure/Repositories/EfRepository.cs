using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Niteco.ApplicationCore.Interfaces.IRepository;
using Niteco.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niteco.Infrastructure.Repositories
{
    public class EfRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly NitecoDbContext _context;

        public EfRepository(NitecoDbContext context) => _context = context;

        public virtual async Task<T> GetByIdAsync(int id) => await _context.Set<T>().FindAsync(id);

        public async Task<IReadOnlyList<T>> ListAllAsync() => await _context.Set<T>().ToListAsync();



        public async Task<T> AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }


        public IDbContextTransaction BeginTransaction() => _context.Database.BeginTransaction();

        public async Task<int> CountAsync() => await _context.Set<T>().CountAsync();

        public async Task<T> FindAsync(long id) => await _context.Set<T>().FindAsync(id);

        public async Task<T> FindAsync(Guid id) => await _context.Set<T>().FindAsync(id);

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
