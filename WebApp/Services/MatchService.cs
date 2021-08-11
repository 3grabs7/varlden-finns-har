using DAL.Matching;
using DAL.Registration;
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

            IEnumerable<RegistrationOfInterest> uncertainScheduleRegistrations = null;
            if (options.MatchUncertainSchedule)
            {
                // Save uncertain schedule registrations
                // How wide should margin for scheduled time be?
            }

            // filter matching time spans
            if (!options.MatchOnlyOnWeeks)
                registrations = FilterTimeSpans(registrations, selectedRegistration);

            // filter selected weeks
            if (!options.MatchOnlyOnSchedule)
                registrations = FilterSelectedWeeks(registrations, selectedRegistration);

            if (uncertainScheduleRegistrations != null)
                registrations.Concat(uncertainScheduleRegistrations);

            return registrations;
        }

        private IEnumerable<RegistrationOfInterest> FilterTimeSpans(IEnumerable<RegistrationOfInterest> registrations,
            RegistrationOfInterest selectedRegistration)
        {
            foreach (var r in registrations)
            {
                bool timeSpanFound = false;
                foreach (var t in r.ScheduledTimeSpans)
                {
                    if (!timeSpanFound && selectedRegistration.ScheduledTimeSpans.Any(ts => ts.Time == t.Time))
                    {
                        yield return r;
                        timeSpanFound = true;
                    }
                }
            }
        }

        private IEnumerable<RegistrationOfInterest> FilterSelectedWeeks(IEnumerable<RegistrationOfInterest> registrations,
            RegistrationOfInterest selectedRegistration)
        {
            foreach (var r in registrations)
            {
                bool weekFound = false;
                foreach (var w in r.Weeks)
                {
                    if (!weekFound && selectedRegistration.Weeks.Any(ts => ts.WeekNumber == w.WeekNumber))
                    {
                        yield return r;
                        weekFound = false;
                    }
                }
            }
        }

        public IEnumerable<Week> GetMatchedWeek(RegistrationOfInterest selectedRegistration,
            RegistrationOfInterest matchedRegistration)
        {
            return matchedRegistration.Weeks
                .Where(w => selectedRegistration.Weeks.Select(x => x.Id).Contains(w.Id));
        }

        public IEnumerable<RegistrationSchedule> GetMatchedTime(RegistrationOfInterest selectedRegistration,
            RegistrationOfInterest matchedRegistration)
        {
            return matchedRegistration.ScheduledTimeSpans
                .Where(ts => selectedRegistration.ScheduledTimeSpans.Select(x => x.Time).Contains(ts.Time));
        }
    }
}
