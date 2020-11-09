using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebService.DataService.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> ReadAll();
        Task<T> ReadById(object id);
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(T entity);
        void Save();
    }
}
