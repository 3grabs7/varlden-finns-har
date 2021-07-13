using DAL.Matching;
using DAL.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Services
{
    public class MatchService : IMatchService
    {
        public async Task<IEnumerable<RegistrationOfInterest>> MatchRegistrationAsync(MatchingOptions options,
            IEnumerable<RegistrationOfInterest> registrations,
            RegistrationOfInterest selectedRegistration)
        {
            // Filter meetingtype
            // if meetingtype is digital skip filtering municapality
            registrations = registrations.Where(r => r.MeetingType == selectedRegistration.MeetingType);

            if (selectedRegistration.MeetingType == MeetingType.Fysiskt)
                registrations = registrations.Where(r => r.Municipality == selectedRegistration.Municipality);

            // filtering of school form
            registrations = selectedRegistration.SchoolForm == SchoolForm.Sfi ?
                registrations.Where(r => r.SchoolForm != SchoolForm.Sfi) :
                registrations.Where(r => r.SchoolForm == SchoolForm.Sfi);

            // group by most time matches
            // as for now return all that have atleast 2 match in time spans
            registrations = registrations.GroupBy(r =>
                r.ScheduledTimeSpans.Count(t => selectedRegistration.ScheduledTimeSpans.Contains(t)))
                .Where(g => g.Key > 1)
                .SelectMany(x => x);

            // filter selected weeks
            // as for now returns all that have atleast 1 match in weeks
            registrations = registrations.Where(r => r.Weeks.Count(w => selectedRegistration.Weeks.Contains(w)) > 0);

            return registrations;
        }
    }


}
