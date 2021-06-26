using DAL.Registration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApp.Services
{
    public interface IScheduleService
    {
        Task CreateScheduleAsync(IEnumerable<RegistrationSchedule> timeSpans, RegistrationOfInterest form);
        Task<IEnumerable<RegistrationSchedule>> LoadScheduleAsync();

    }
}
