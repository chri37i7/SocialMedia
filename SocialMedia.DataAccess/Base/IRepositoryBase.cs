using SocialMedia.Entities.Models.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.DataAccess.Base
{
    /// <summary>
    /// Base repository interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepositoryBase<TModel, TContext>
    {
        TContext Context { get; set; }

        Task AddAsync(TModel t);
        Task<TModel> GetByIdAsync(int? id);
        Task<IEnumerable<TModel>> GetAllAsync();
        Task UpdateAsync(TModel t);
        Task DeleteAsync(TModel t);
        Task<bool> Exists(int? id);
    }
}