using DAL;
using DAL.Registration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data;

namespace WebApp.Services
{
    public class PaginationService
    {
        private readonly ApplicationDbContext _context;
        public PaginationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<int> GetCount()
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> GetPaginatedResult<TEntity>(int currentPage, int pageSize) where TEntity : Entity
        {

            //var data = await GetData();
            //return data.OrderBy(d => d.Id).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> GetPaginatedResult<TEntity>(int currentPage, int pageSize, string sortBy) where TEntity : Entity
        {
            //var data = await GetData();
            //return data.AsQueryable().OrderBy(sortBy).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            throw new NotImplementedException();
        }

        private async Task<List<TEntity>> GetData<TEntity>() where TEntity : Entity
        {
            return await _context.Set<TEntity>().Cast<TEntity>().ToListAsync();
        }
    }
}
