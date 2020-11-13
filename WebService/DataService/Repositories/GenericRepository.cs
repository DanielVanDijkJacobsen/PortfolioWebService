using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebService.DataService.Repositories
{
    public class GenericRepository <T> : IGenericRepository<T> where T : class
    {
        public readonly ImdbContext Context;

        public GenericRepository(ImdbContext context)
        {
            this.Context = context;
        }
        public async Task<T> ReadById(object id)
        {
            return await Context.Set<T>().FindAsync(id);
        }
        public async Task<T> ReadById(object[] id)
        {
            return await Context.Set<T>().FindAsync(id);
        }
        public async Task<List<T>> ReadAll()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public async Task<T> Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Update(T entity)
        {
            var updatedEntity = Context.Set<T>().Update(entity).Entity;
            await Context.SaveChangesAsync();
            return updatedEntity;
        }

        public async Task<T> Create(T entity)
        {
            var newEntity = Context.Set<T>().AddAsync(entity).Result.Entity;
            await Context.SaveChangesAsync();
            return newEntity;
        }
        public async void Save()
        {
            await Context.SaveChangesAsync();
        }
    }
}
