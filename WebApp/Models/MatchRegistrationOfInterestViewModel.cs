using DAL.Registration;
using System.Collections.Generic;

namespace WebApp.Models
{
    public class MatchRegistrationOfInterestViewModel
    {
        public RegistrationOfInterest Form { get; set; }
        public IEnumerable<RegistrationOfInterest> Matches { get; set; }
    }
}
