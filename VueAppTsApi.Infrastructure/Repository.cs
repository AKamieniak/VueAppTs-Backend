using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VueAppTsApi.Core.Interfaces;
using VueAppTsApi.Infrastructure.Data;

namespace VueAppTsApi.Infrastructure
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public Repository(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public async Task Add<TEntity>(TEntity entity)
            where TEntity : class, IEntity
        {
            await _dbContext.AddAsync(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAll<TEntity>()
            where TEntity : class, IEntity
        {
            return await Task.Run(() => _dbContext.Set<TEntity>());
        }

        public async Task<IEnumerable<TEntity>> GetByIds<TEntity>(IEnumerable<int> ids)
            where TEntity : class, IEntity
        {
            return await GetByCondition<TEntity>(e => ids.Contains(e.Id));
        }

        public async Task<IEnumerable<TEntity>> GetByCondition<TEntity>(Expression<Func<TEntity, bool>> condition)
            where TEntity : class, IEntity
        {
            return await GetByConditions(new[] { condition });
        }

        public async Task<IEnumerable<TEntity>> GetByConditions<TEntity>(IEnumerable<Expression<Func<TEntity, bool>>> conditions)
            where TEntity : class, IEntity
        {
            IQueryable<TEntity> queryable = await Task.Run(() => _dbContext.Set<TEntity>());

            if (conditions != null)
            {
                foreach (var condition in conditions)
                {
                    queryable = queryable.Where(condition);
                }
            }

            return queryable;
        }

        public async Task<TEntity> GetById<TEntity>(int id)
            where TEntity : class, IEntity
        {
            return (await GetByCondition<TEntity>(e => e.Id == id)).FirstOrDefault();
        }

        public async Task Remove<TEntity>(TEntity entity)
            where TEntity : class, IEntity
        {
            await Task.Run(() => _dbContext.Remove(entity));
        }

        public async Task Update<TEntity>(TEntity entity)
            where TEntity : class, IEntity
        {
            await Task.Run(() => _dbContext.Update(entity));
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}