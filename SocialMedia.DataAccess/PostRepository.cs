using Microsoft.EntityFrameworkCore;

using SocialMedia.DataAccess.Base;
using SocialMedia.Entities.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.DataAccess
{
    /// <summary>
    /// Specialized version of <see cref="RepositoryBase{T}"/> for <see cref="AspNetPosts"/> 
    /// to include <see cref="AspNetPosts.FkUser"/>
    /// </summary>
    public class PostRepository : RepositoryBase<AspNetPosts>
    {
        /// <summary>
        /// Gets an item by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override async Task<AspNetPosts> GetByIdAsync(int id)
        {
            return await context.Set<AspNetPosts>().Include(p => p.FkUser).FirstOrDefaultAsync(p => p.PkId == id);
        }

        /// <summary>
        /// Gets all the items
        /// </summary>
        /// <returns></returns>
        public override async Task<IEnumerable<AspNetPosts>> GetAllAsync()
        {
            return await context.Set<AspNetPosts>().Include(p => p.FkUser).ToListAsync();
        }
    }
}