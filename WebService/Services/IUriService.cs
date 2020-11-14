﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService.Filters;

namespace WebService.Services
{
    public interface IUriService
    {
        public Uri GetPageUri(PaginationFilter filter, string route);
    }
}
