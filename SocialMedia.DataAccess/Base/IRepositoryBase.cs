using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.DataAccess.Base
{
    /// <summary>
    /// Generic interface specifying encapsulation of DbContext funtionality
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    /// <typeparam name="TContext"></typeparam>
    public interface IRepositoryBase<TModel>
    {
        Task AddAsync(TModel t);
        Task<TModel> GetByIdAsync(int? id);
        Task<IEnumerable<TModel>> GetAllAsync();
        Task UpdateAsync(TModel t);
        Task DeleteAsync(TModel t);
        Task<bool> ExistsAsync(int? id);
    }
}