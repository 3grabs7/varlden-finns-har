using DAL.Registration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApp.Services
{
    public interface IScheduleService
    {
        Task CreateSchedule(IEnumerable<AvailableTimeSpan> timeSpans, RegistrationOfInterest form);
    }
}
