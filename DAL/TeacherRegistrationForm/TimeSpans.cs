using System;

namespace DAL.TeacherRegistrationForm
{
    public class TimeSpans : Entity
    {
        public Weekday Weekday { get; set; }
        public DateTime TimeSpan { get; set; } // Format this to hh:mm (only 30min gaps)
        public TeacherRegistrationForm Form { get; set; }
        public TeacherRegistrationForm FormOutsideSchedule { get; set; }
    }
}
