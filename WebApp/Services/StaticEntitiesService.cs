using DAL.Registration;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Data;

namespace WebApp.Services
{
    public class StaticEntitiesService
    {
        private readonly ApplicationDbContext _context;

        public StaticEntitiesService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Municipality>> GetMunicipalitiesAsync()
            => await _context.Municipalities.AsNoTracking().ToListAsync();

        public async Task<List<Subject>> GetSubjectsAsync()
            => await _context.Subjects.AsNoTracking().ToListAsync();

    }
}
