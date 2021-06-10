using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.TeacherRegistrationForm
{
    public class ScheduledTimeSpan : Entity
    {
        [Display(Name = "Veckodag")]
        public Weekday Weekday { get; set; }

        [Display(Name = "Tid")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime Time { get; set; } // Format this to hh:mm (only 30min gaps)

        [Display(Name = "Utanför schema")]
        public bool IsOutsideSchedule { get; set; }
        public TeacherRegistrationForm TeacherRegistrationForm { get; set; }
    }
}
