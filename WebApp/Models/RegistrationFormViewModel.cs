using DAL.Registration;
using System.Collections.Generic;

namespace WebApp.Models
{
    public class RegistrationFormViewModel
    {
        public List<AvailableTimeSpan> TimeSpans { get; set; }
        public List<Subject> Subjects { get; set; }
        public IEnumerable<Municipality> Municipalities { get; set; }
        public RegistrationOfInterest Form { get; set; }

        public bool SubmitSuccessfull { get; set; }
    }
}
