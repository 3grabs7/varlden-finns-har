using DAL.Registration;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using WebApp.Data;

namespace WebApp.Repositories
{
    public class RegistrationOfInterestRepository : IRegistrationOfInterestRepository
    {
        private readonly ApplicationDbContext _context;

        public RegistrationOfInterestRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<RegistrationOfInterest> GetAsync(int id) => await _context.RegistrationOfInterests.FindAsync(id);

        public async Task<IEnumerable<RegistrationOfInterest>> GetAllAsync()
            => await _context.RegistrationOfInterests
            .Include(t => t.ScheduledTimeSpans)
            .Include(t => t.Municipality)
            .Include(t => t.Subjects)
            .AsNoTracking()
            .ToListAsync();

        public async Task<IEnumerable<RegistrationOfInterest>> GetRangeAsync(int count)
        {
            var forms = await _context.RegistrationOfInterests.ToListAsync();
            return forms.Take(count);
        }

        public async Task<RegistrationOfInterest> CreateAsync(RegistrationOfInterest form)
        {
            var tracking = await _context.AddAsync(form);
            await _context.SaveChangesAsync();
            return tracking.Entity;
        }

        public async Task DeleteAsync(RegistrationOfInterest form)
        {
            _context.Remove(form);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.RegistrationOfInterests.FindAsync(id);
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public Task<RegistrationOfInterest> EditAsync(RegistrationOfInterest form)
        {
            throw new System.NotImplementedException();
        }

        public string SuccessMessage(RegistrationOfInterest form) =>
                    $"Tack {form.FirstName}. Din ansökan kommer bearbetas." +
                    $"Du kommer kontaktas via mail på {form.Email} eller via telefonnummer {form.PhoneNumber}";

        /*                       
         * *** PAGINATION IMPLEMENTATION *** *
         */

        public async Task<IEnumerable<RegistrationOfInterest>> GetPaginatedResult(int currentPage, int pageSize)
        {
            var data = await GetData();
            return data.OrderBy(d => d.Id).Skip((currentPage - 1) * pageSize).Take(pageSize);
        }

        public async Task<IEnumerable<RegistrationOfInterest>> GetPaginatedResult(int currentPage, int pageSize, string sortBy)
        {
            if (sortBy == null) sortBy = "Id";
            var data = await GetData();
            return data.AsQueryable().OrderBy(sortBy).Skip((currentPage - 1) * pageSize).Take(pageSize);
        }

        public async Task<int> GetCount()
        {
            var data = await GetData();
            return data.Count();
        }

        public async Task<IEnumerable<RegistrationOfInterest>> GetData()
            => await _context.Set<RegistrationOfInterest>().ToListAsync();

    }
}
