using DAL.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data;

namespace WebApp.Repositories
{
    public class AvailableTimeSpanRepository : IAvailableTimeSpanRepository
    {
        private readonly ApplicationDbContext _context;
        public AvailableTimeSpanRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateSchedule(IEnumerable<AvailableTimeSpan> timeSpans, RegistrationOfInterest form)
        {
            foreach (var timeSpan in timeSpans)
            {
                timeSpan.TeacherRegistrationForm = form;
            }

            await _context.AddRangeAsync(timeSpans.Where(t => t.IsMarked));
            await _context.SaveChangesAsync();
        }
    }
}
