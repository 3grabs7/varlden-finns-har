﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Registration
{
    public class RegistrationOfInterest : Entity
    {
        // Teacher info
        [Display(Name = "Namn")]
        public string Name { get; set; }
        public string Email { get; set; }

        [Display(Name = "Telefonnummer")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Skola")]
        public string School { get; set; } // Create tables for School later

        [Display(Name = "Kommun")]
        public Municipality Municipality { get; set; } // Create tables for municipality later

        [Display(Name = "Skolform")]
        public SchoolForm SchoolForm { get; set; }

        [Display(Name = "Ämnen")]
        public string TeachersSubjects { get; set; } // Enum or subject class, keep as csv formatted now

        // Student group info
        [Display(Name = "Årskurs")]
        public int Grade { get; set; }

        [Display(Name = "Elevernas ämnen")]
        public string StudentGroupSubjects { get; set; } // Enum or subject class, keep as csv formatted now

        [Display(Name = "Andra ämnen av intresse")]
        public string AdditionalSubjectsOfInterest { get; set; }

        [Display(Name = "Program")]
        public string Program { get; set; }

        // Information about meetings
        [Display(Name = "Mötestyp")]
        public MeetingType MeetingType { get; set; }

        public ICollection<AvailableTimeSpan> ScheduledTimeSpans { get; set; }

        [Display(Name = "Veckor")]
        public int Weeks { get; set; }

        [Display(Name = "Önskade Veckor")]
        public WeeksWanted WeeksWanted { get; set; }

    }
}
