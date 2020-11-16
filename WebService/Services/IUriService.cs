using System;
using WebService.Filters;

namespace WebService.Services
{
    public interface IUriService
    {
        public Uri GetPageUri(PaginationFilter filter, string route);
    }
}
