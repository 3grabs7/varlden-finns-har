using DAL.Registration;
using System.Collections.Generic;

namespace WebApp.Models
{
    public class RegistrationOfInterestViewModel : PaginationBase
    {
        public RegistrationOfInterest Form { get; set; }
        public IList<AvailableTimeSpan> TimeSpans { get; set; }
        public IEnumerable<RegistrationOfInterest> Registrations { get; set; }
        public bool SubmitSuccessfull { get; set; }

        // Matching related properties
        public bool HasInitializedMatching { get; set; }

    }
}
