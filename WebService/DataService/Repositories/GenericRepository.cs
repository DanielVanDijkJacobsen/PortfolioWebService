using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebService.Filters;

namespace WebService.DataService.Repositories
{
    public class GenericRepository <T> : IGenericRepository<T> where T : class
    {
        public readonly ImdbContext Context;

        public GenericRepository(ImdbContext context)
        {
            this.Context = context;
        }

        public async Task<int> CountAll()
        {
           return await Context.Set<T>().CountAsync();
        }

        public async Task<T> ReadById(object id)
        {
            return await Context.Set<T>().FindAsync(id);
        }
        public async Task<T> ReadById(object[] id)
        {
            return await Context.Set<T>().FindAsync(id);
        }
        public async Task<List<T>> ReadAll(PaginationFilter paginationFilter = null)
        {
            if (paginationFilter != null)
            {
                return await Context.Set<T>().Skip((paginationFilter.PageNumber - 1) * paginationFilter.PageSize)
                    .Take(paginationFilter.PageSize)
                    .ToListAsync();
            }

            return await Context.Set<T>().ToListAsync();
        }

        //public async Task<List<T>> WhereByUserId(int? id, Func<T, int> property, PaginationFilter paginationFilter = null)
        //{
        //    if (paginationFilter != null)
        //    {
        //        return await Context.Set<T>().Skip((paginationFilter.PageNumber - 1) * paginationFilter.PageSize)
        //            .Take(paginationFilter.PageSize)
        //            .Where(x => property(x) == id)
        //            .ToListAsync();
        //    }
        //    return await Context.Set<T>().Where(x => property(x) == id).ToListAsync();
        //}

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
