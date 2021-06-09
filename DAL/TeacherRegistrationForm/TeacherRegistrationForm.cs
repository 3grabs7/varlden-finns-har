using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.TeacherRegistrationForm
{
    public class TeacherRegistrationForm : Entity
    {
        // Teacher info
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string School { get; set; } // Create tables for School later
        public string Municipality { get; set; } // Create tables for municipality later
        public SchoolForm SchoolForm { get; set; }
        public string TeachersSubjects { get; set; } // Enum or subject class, keep as csv formatted now

        // Student group info
        public int Grade { get; set; }
        public string StudentGroupSubjects { get; set; } // Enum or subject class, keep as csv formatted now
        public string AdditionalSubjectsOfInterest { get; set; }
        public string Program { get; set; }

        // Information about meetings
        public MeetingType MeetingType { get; set; }
        public ICollection<ScheduledTimeSpan> ScheduledTimeSpans { get; set; }

    }
}
