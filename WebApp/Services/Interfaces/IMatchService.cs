using DAL.Matching;
using DAL.Registration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApp.Services
{
    public interface IMatchService
    {
        public Task<IEnumerable<RegistrationOfInterest>> MatchRegistrationAsync(MatchingOptions options,
            IEnumerable<RegistrationOfInterest> registrations,
            RegistrationOfInterest slectedRegistration);
    }
}
