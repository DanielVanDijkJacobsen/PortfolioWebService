﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebService.DataService.DTO;

namespace WebService.DataService.Repositories
{
    class TitleAliasRepository : GenericRepository<TitleAlias>
    {
        public TitleAliasRepository(ImdbContext context) : base(context)
        {

        }

        public async Task<List<TitleAlias>> WhereByTitleId(object? id)
        {
            return await Context.Set<TitleAlias>().Where(titleAlias => titleAlias.TitleId == id).ToListAsync();
        }
    }
}