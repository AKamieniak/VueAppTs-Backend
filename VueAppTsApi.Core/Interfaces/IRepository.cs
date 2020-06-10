using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace VueAppTsApi.Core.Interfaces
{
    public interface IRepository
    {
        Task<IEnumerable<TEntity>> GetAll<TEntity>()
            where TEntity : class, IEntity;

        Task<IEnumerable<TEntity>> GetByCondition<TEntity>(Expression<Func<TEntity, bool>> condition)
            where TEntity : class, IEntity;

        Task<IEnumerable<TEntity>> GetByConditions<TEntity>(IEnumerable<Expression<Func<TEntity, bool>>> conditions)
            where TEntity : class, IEntity;

        Task<IEnumerable<TEntity>> GetByIds<TEntity>(IEnumerable<int> ids)
            where TEntity : class, IEntity;

        Task<TEntity> GetById<TEntity>(int id)
            where TEntity : class, IEntity;

        Task Add<TEntity>(TEntity entity)
            where TEntity : class, IEntity;

        Task Update<TEntity>(TEntity entity)
            where TEntity : class, IEntity;

        Task Remove<TEntity>(TEntity entity)
            where TEntity : class, IEntity;

        Task SaveAsync();
    }
}