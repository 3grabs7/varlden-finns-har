using DAL.Registration;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data;

namespace WebApp.Services
{
    public class StaticEntitiesService : IStaticEntitiesService
    {
        private readonly ApplicationDbContext _context;

        public StaticEntitiesService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Municipality>> GetMunicipalitiesAsync()
            => await _context.Municipalities.AsNoTracking()
            .OrderBy(m => m.Name)
            .ToListAsync();

        public async Task<IEnumerable<IGrouping<SchoolForm, Subject>>> GetSubjectsAsync()
        {
            var result = await _context.Subjects.AsNoTracking().ToListAsync();
            return result.GroupBy(s => s.SchoolForm);
        }

    }
}
