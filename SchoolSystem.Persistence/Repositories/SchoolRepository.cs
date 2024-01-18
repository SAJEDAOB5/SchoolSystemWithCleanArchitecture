using Microsoft.EntityFrameworkCore;
using School1system.Application.Contracts;
using SchoolSystem.Domain.Entites;
using SchoolSystem.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Persistence.Repositories
{
    public class SchoolRepository<T> : ISchoolRepository<T> where T : class
    {
        private readonly AppDbContext _dbContext;

        public SchoolRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var result = await _dbContext.Set<T>().FindAsync(id);
            return result;
        }
        public async Task AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
           
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var Result = await _dbContext.Set<T>().FindAsync(id);

            if (Result != null)
            {
                _dbContext.Set<T>().Remove(Result);
                await _dbContext.SaveChangesAsync();
            }
            
        }

        public IQueryable<T> Get()
        {
            return _dbContext.Set<T>();
        }


    }
}
