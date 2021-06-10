using DAL.TeacherRegistrationForm;
using System.Collections.Generic;

namespace WebApp.Models
{
    public class TeacherRegistrationFormViewModel
    {
        public TeacherRegistrationForm Form { get; set; }
        public IEnumerable<ScheduledTimeSpan> TimeSpans { get; set; }
        public bool SubmitSuccessfull { get; set; }
    }
}
