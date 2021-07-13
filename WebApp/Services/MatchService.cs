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
            registrations = registrations.Where(r => r.MeetingType == selectedRegistration.MeetingType);

            // if meetingtype is physical
            if (selectedRegistration.MeetingType == MeetingType.Fysiskt)
            {
                // filter municapality
                registrations = registrations.Where(r => r.Municipality == selectedRegistration.Municipality);

                // make sure there are no matches between immobile groups
                if (!selectedRegistration.CanVisitMatch)
                    registrations = registrations.Where(r => r.CanVisitMatch);

                if (!selectedRegistration.CanHostMatch)
                    registrations = registrations.Where(r => r.CanHostMatch);
            }

            // filtering of school form
            registrations = selectedRegistration.SchoolForm == SchoolForm.Sfi ?
                registrations.Where(r => r.SchoolForm != SchoolForm.Sfi) :
                registrations.Where(r => r.SchoolForm == SchoolForm.Sfi);

            // filter matching time spans
            registrations = FilterTimeSpans(registrations, selectedRegistration);

            // filter selected weeks
            registrations = FilterSelectedWeeks(registrations, selectedRegistration);

            return registrations;
        }

        private IEnumerable<RegistrationOfInterest> FilterTimeSpans(IEnumerable<RegistrationOfInterest> registrations,
            RegistrationOfInterest selectedRegistration)
        {
            foreach (var r in registrations)
            {
                foreach (var t in r.ScheduledTimeSpans)
                {
                    if (selectedRegistration.ScheduledTimeSpans.Any(ts => ts.Time == t.Time))
                        yield return r;
                }
            }
        }

        private IEnumerable<RegistrationOfInterest> FilterSelectedWeeks(IEnumerable<RegistrationOfInterest> registrations,
    RegistrationOfInterest selectedRegistration)
        {
            foreach (var r in registrations)
            {
                foreach (var w in r.Weeks)
                {
                    if (selectedRegistration.Weeks.Any(ts => ts.WeekNumber == w.WeekNumber))
                        yield return r;
                }
            }
        }
    }


}
