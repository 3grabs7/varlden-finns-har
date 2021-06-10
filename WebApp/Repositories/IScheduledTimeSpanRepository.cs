using DAL.TeacherRegistrationForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Repositories
{
    public interface IScheduledTimeSpanRepository
    {
        Task CreateSchedule(IEnumerable<ScheduledTimeSpan> timeSpans, TeacherRegistrationForm form);
    }
}
