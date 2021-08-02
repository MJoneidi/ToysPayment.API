using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ToysPayment.API.Models.Contracts;
using ToysPayment.API.Models.Entities;

namespace ToysPayment.API.Infrastructure.Data.Repositories
{
    public class EfRepository<T> : IAsyncRepository<T> where T : BaseEntity
    {

        #region Fields

        protected CustomerDbContext _dbContext;

        #endregion

        public EfRepository(CustomerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Public Methods

        public Task<T> GetByIdAsync(int id) => _dbContext.Set<T>().FindAsync(id).AsTask();

        public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
            => _dbContext.Set<T>().FirstOrDefaultAsync(predicate);

        public async Task AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().Where(predicate).ToListAsync();
        }

        public Task<int> CountAllAsync() => _dbContext.Set<T>().CountAsync();

        public Task<int> CountWhereAsync(Expression<Func<T, bool>> predicate)
            => _dbContext.Set<T>().CountAsync(predicate);

        #endregion

    }
}