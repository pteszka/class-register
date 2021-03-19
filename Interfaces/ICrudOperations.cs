using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClassRegister.Interfaces 
{
    public interface ICrudOperations<T, K>
    {
        Task<IEnumerable<T>> GetAsync();
        Task<T> GetAsync(K id);
        Task AddAsync(T entity);
        Task RemoveAsync(K id);
        Task UpdateAsync(T entity);
        Task<bool> SaveAsync();
    }
}