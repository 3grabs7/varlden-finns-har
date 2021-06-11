using DAL.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Repositories
{
    public interface IAvailableTimeSpanRepository
    {
        Task CreateSchedule(IEnumerable<AvailableTimeSpan> timeSpans, RegistrationOfInterest form);
    }
}
