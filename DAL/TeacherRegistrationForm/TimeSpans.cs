using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.TeacherRegistrationForm
{
    public class TimeSpans : Entity
    {
        public Weekday Weekday { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime TimeSpan { get; set; } // Format this to hh:mm (only 30min gaps)
        public TeacherRegistrationForm Form { get; set; }
        public TeacherRegistrationForm FormOutsideSchedule { get; set; }
    }
}
