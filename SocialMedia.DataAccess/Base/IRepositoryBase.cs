using SocialMedia.Entities.Models.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.DataAccess.Base
{
    /// <summary>
    /// Base repository interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepositoryBase<T>
    {
        SocialMediaContext Context { get; set; }

        Task AddAsync(T t);
        Task<T> GetByIdAsync(int? id);
        Task<IEnumerable<T>> GetAllAsync();
        Task UpdateAsync(T t);
        Task DeleteAsync(T t);
        Task<bool> Exists(int? id);
    }
}