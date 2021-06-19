using DAL.Registration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data;

namespace WebApp.Services
{
    public class RegistrationFormService
    {
        private readonly ApplicationDbContext _context;
        public RegistrationFormService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateRegistrationFormAsync(RegistrationOfInterest form)
        {
            var municipality = await _context.Municipalities.FindAsync(form.MunicipalityRefId);
            var subjects = _context.Subjects.Where(s => form.Subjects.Contains(s)).ToList();

            form.Municipality = municipality;
            form.Subjects = subjects;

            await _context.AddAsync(form);
            await _context.SaveChangesAsync();
        }

        public async Task AppendAdressAsync(RegistrationOfInterest form, Adress adress)
        {

        }

        // Get all municipalities from database
        public async Task<IEnumerable<Municipality>> GetMunicipalitiesAsync()
            => await _context.Municipalities.AsNoTracking()
            .OrderBy(m => m.Name)
            .ToListAsync();

        // Get all subjects from database
        public async Task<IEnumerable<IGrouping<SchoolForm, Subject>>> GetSubjectsAsync()
        {
            var result = await _context.Subjects.AsNoTracking().ToListAsync();
            return result.GroupBy(s => s.SchoolForm);
        }
    }
}
