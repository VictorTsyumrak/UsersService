using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IRepositoryAsync<TEntity> where TEntity : class 
    {
        Task<TEntity> GetAsync(object id);
        Task<List<TEntity>> GetAsync();
    }
}
