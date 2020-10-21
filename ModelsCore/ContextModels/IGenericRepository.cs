using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ModelsCore.ContextModels
{
    /// <summary>
    /// We use an interface to allow dependency injection
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IGenericRepository<TEntity>
    {
        /// <summary>
        /// Find function
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        Task<TEntity> FindAsync(params object[] keys);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task UpdateAsync(TEntity entity);

        /// <summary>
        /// Create a new Entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task Create(TEntity entity);

        /// <summary>
        /// Works like the Linq Where Function
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Works like the Linq FirstOrDefaultFunction Function
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Other Table Reference
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        DbSet<T> QueryOver<T>() where T : class;
    }
}
