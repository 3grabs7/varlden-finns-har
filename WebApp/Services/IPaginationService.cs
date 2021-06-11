using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Services
{
    public interface IPaginationService<TEntity>
    {
        Task<IEnumerable<TEntity>> GetPaginatedResult(int currentPage, int pageSize);
        Task<IEnumerable<TEntity>> GetPaginatedResult(int currentPage, int pageSize, string sortBy);
        Task<int> GetCount();
        Task<IEnumerable<TEntity>> GetData();
    }
}
