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

            // implement filtering of school form
            // look up priority



            return registrations;
        }
    }


}
