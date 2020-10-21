using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ModelsCore.ContextModels
{
    /// <summary>
    /// Generic class so we don't have to keep writing functions over and over
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        DbContext Context { get; }

        /// <summary>
        /// This allows us to treat the table similar to a List of objects.
        /// </summary>
        DbSet<TEntity> Set { get
            {
                return Context.Set<TEntity>();
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public GenericRepository(DbContext context)
        {
            Context = context;
        }

        #region REST Functions

        /// <summary>
        /// A function that retrieves an entity
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public async Task<TEntity> FindAsync(params object[] keys) =>
            await Context.FindAsync<TEntity>(keys);

        /// <summary>
        /// Here we Update the function
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task UpdateAsync(TEntity entity)
        {
            Context.Update(entity);

            // Notice we save it after we added the entity
            // This is neccecary
            await Context.SaveChangesAsync();
        }

        /// <summary>
        /// This function creates new entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task Create(TEntity entity)
        {
            Context.Add(entity);

            // Notice we save it after we added the entity
            // This is neccecary
            await Context.SaveChangesAsync();
        }

        #endregion

        #region Conditional Retrieval


        /// <summary>
        /// Below we use functions similar to Linq Where
        /// 
        /// Notice we don't call Task or async here.
        /// It's because IQueryable doesn't actually get the data.
        /// It just prepares the data to be queried. 
        /// 
        /// This is know as delayed Execution.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate) =>
            Set.Where(predicate);


        /// <summary>
        /// When retrieving a single entity, hwoever, we do need to find it immedaitely
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> predicate) =>
            await Set.FirstOrDefaultAsync(predicate);

        #endregion

        #region Cross Table Functionality

        /// <summary>
        /// We would use this if we want to do joins or compare tables
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public DbSet<T> QueryOver<T>() where T : class =>
            Context.Set<T>();

        #endregion
    }
}
