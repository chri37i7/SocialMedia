using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.DataAccess.Base
{
    /// <summary>
    /// Generic repository class for encapsulation of DbContext funtionality
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RepositoryBase<TModel, TContext> : IRepositoryBase<TModel, TContext>
        where TModel : class
        where TContext : DbContext, new()
    {
        #region Fields
        protected TContext context;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes the context with the provided object
        /// </summary>
        /// <param name="context"></param>
        public RepositoryBase(TContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Initializes the context
        /// </summary>
        public RepositoryBase()
        {
            context = new TContext();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Database Context
        /// </summary>
        public virtual TContext Context
        {
            get { return context; }
            set { context = value; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Adds the provided object to the context,
        /// and saves the changes.
        /// </summary>
        /// <param name="t"></param>
        public virtual async Task AddAsync(TModel t)
        {
            context.Set<TModel>().Add(t);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Gets an object with the provided id,
        /// returns null if nothing is found.
        /// </summary>
        /// <param name="id"></param>
        public virtual async Task<TModel> GetByIdAsync(int? id)
        {
            return await context.Set<TModel>().FindAsync(id);
        }

        /// <summary>
        /// Gets all the objects from the context.
        /// </summary>
        public virtual async Task<IEnumerable<TModel>> GetAllAsync()
        {
            return await context.Set<TModel>().ToListAsync();
        }

        /// <summary>
        /// Updates the provided object in the context,
        /// and saves the changes.
        /// </summary>
        /// <returns></returns>
        public virtual async Task UpdateAsync(TModel t)
        {
            context.Set<TModel>().Update(t);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes the provided object in the context,
        /// and saves the changes.
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public virtual async Task DeleteAsync(TModel t)
        {
            context.Set<TModel>().Remove(t);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Checks if an object with the provided id exists.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<bool> Exists(int? id)
        {
            return await context.Set<TModel>().FindAsync(id) != null;
        } 
        #endregion
    }
}