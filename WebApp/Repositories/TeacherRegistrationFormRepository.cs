using DAL.TeacherRegistrationForm;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data;

namespace WebApp.Repositories
{
    public class TeacherRegistrationFormRepository : ITeacherRegistrationFormRepository
    {
        private readonly ApplicationDbContext _context;

        public TeacherRegistrationFormRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public string SuccessMessage(TeacherRegistrationForm form) =>
                    $"Tack {form.Name}. Din ansökan kommer bearbetas." +
                    $"Du kommer kontaktas via mail på {form.Email} eller via telefonnummer {form.PhoneNumber}";

        public async Task<TeacherRegistrationForm> CreateAsync(TeacherRegistrationForm form)
        {
            var tracking = await _context.AddAsync(form);
            await _context.SaveChangesAsync();
            return tracking.Entity;
        }

        public async Task DeleteAsync(TeacherRegistrationForm form)
        {
            _context.Remove(form);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.TeacherRegistrationForms.FindAsync(id);
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public Task<TeacherRegistrationForm> EditAsync(TeacherRegistrationForm form)
        {
            throw new System.NotImplementedException();
        }

        public async Task<TeacherRegistrationForm> GetAsync(int id)
            => await _context.TeacherRegistrationForms.FindAsync(id);

        public async Task<IEnumerable<TeacherRegistrationForm>> GetRangeAsync(int count)
        {
            var forms = await _context.TeacherRegistrationForms.ToListAsync();
            return forms.Take(count);

        }
    }
}
