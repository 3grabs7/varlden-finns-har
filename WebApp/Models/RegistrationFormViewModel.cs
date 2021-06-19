using DAL.Registration;
using System.Collections.Generic;
using System.Linq;

namespace WebApp.Models
{
    public class RegistrationFormViewModel
    {
        public List<AvailableTimeSpan> TimeSpans { get; set; }
        public IEnumerable<IGrouping<SchoolForm, Subject>> Subjects { get; set; }
        public IEnumerable<Municipality> Municipalities { get; set; }
        public RegistrationOfInterest Form { get; set; }

        public bool SubmitSuccessfull { get; set; }
    }
}
