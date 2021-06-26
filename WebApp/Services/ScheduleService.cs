using DAL.Registration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data;
using WebApp.Utils;

namespace WebApp.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly ApplicationDbContext _context;
        public ScheduleService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateScheduleAsync(IEnumerable<RegistrationSchedule> timeSpans, RegistrationOfInterest form)
        {
            if (timeSpans == null) return;

            foreach (var timeSpan in timeSpans)
            {
                timeSpan.TeacherRegistrationForm = form;
            }

            await _context.AddRangeAsync(timeSpans.Where(t => t.IsMarked));
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<RegistrationSchedule>> LoadScheduleAsync()
        {
            DateTime refTime = new(2021, 1, 1, 8, 0, 0);
            DateTime maxTime = new(2021, 1, 1, 18, 0, 0);
            var weekDays = EnumTools.GetValues<Weekday>().ToList();

            List<RegistrationSchedule> timeSpans = new();

            for (int i = 0; i < 100; i++)
            {
                var ts = new RegistrationSchedule();
                ts.Time = refTime;
                ts.Weekday = weekDays[i / 20];
                timeSpans.Add(ts);
                refTime = refTime.AddMinutes(30);
                ts.IsMarked = false;

                if (refTime == maxTime) refTime = new(2021, 1, 1, 8, 0, 0);
            }

            return timeSpans;
        }
    }
}
