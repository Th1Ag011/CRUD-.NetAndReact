using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VestibularApp.Domain.Interfaces;
using VestibularApp.Infrastructure.Data;

namespace VestibularApp.Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly VestibularContext _context;
        protected readonly DbSet<T> _dbContext;

        public GenericRepository(VestibularContext context)
        {
            _context = context;
            _dbContext = _context.Set<T>(); 
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
           return await _dbContext.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _dbContext.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _dbContext.Update(entity);
        }

        public void Delete(T entity)
        {
            _dbContext.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
