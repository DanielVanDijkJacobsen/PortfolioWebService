using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebService.Filters;

namespace WebService.DataService.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> ReadAll(PaginationFilter paginationFilter = null);
        Task<int> CountAll();
        Task<T> ReadById(object id);
        Task<T> ReadById(object[] id);
        //public Task<List<T>> WhereByUserId(int? id, Func<T, int> property, PaginationFilter paginationFilter = null);
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(T entity);
        void Save();
    }
}
