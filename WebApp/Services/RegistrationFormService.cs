using DAL.Registration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data;

namespace WebApp.Services
{
    public class RegistrationFormService : IRegistrationFormService
    {
        private readonly ApplicationDbContext _context;
        private readonly IGeocodingService _geocodeService;

        public RegistrationFormService(ApplicationDbContext context,
            IGeocodingService geocodeService)
        {
            _context = context;
            _geocodeService = geocodeService;
        }

        public async Task CreateRegistrationFormAsync(RegistrationOfInterest form)
        {
            if (form is null)
            {
                return;
            }

            var municipality = await _context.Municipalities.FindAsync(form.MunicipalityRefId);
            var subjects = _context.Subjects.Where(s => form.Subjects.Contains(s)).ToList();

            form.Municipality = municipality;
            form.Subjects = subjects;

            var coordinates = await _geocodeService.GetCoordinatesAsync(form.SchoolAdress, form.Municipality);
            form.SchoolAdress.Longitude = (decimal)coordinates[0];
            form.SchoolAdress.Latitude = (decimal)coordinates[1];

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

        public async Task<IEnumerable<Week>> GetWeeksAsync()
        {
            var year = DateTime.Now.Year;
            return await _context.Weeks.ToListAsync();
        }
    }
}
