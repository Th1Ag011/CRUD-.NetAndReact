using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VestibularApp.Domain.Interfaces;
using VestibularApp.Application.Services.Interfaces;

namespace VestibularApp.Application.Services
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        protected readonly IGenericRepository<T> _genericRepository;

        public GenericService(IGenericRepository<T> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _genericRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _genericRepository.GetAllAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _genericRepository.AddAsync(entity);
            await _genericRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _genericRepository.Update(entity);
            await _genericRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _genericRepository.GetByIdAsync(id);
            if (entity != null)
            {
                _genericRepository.Delete(entity);
                await _genericRepository.SaveChangesAsync();
            }
        }
    }
}
