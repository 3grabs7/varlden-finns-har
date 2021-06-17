using System.Collections.Generic;
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
        // as for now hard code municipality

        [Display(Name = "Skolform")]
        public SchoolForm SchoolForm { get; set; }

        [Display(Name = "Ämnen")]
        public string TeachersSubjects { get; set; } // Enum or subject class, keep as csv formatted now

        // Student group info
        [Display(Name = "Årskurs")]
        public int Grade { get; set; }

        // Only for gymnasie
        [Display(Name = "Program")]
        public string Program { get; set; }

        // Information about meetings
        [Display(Name = "Mötestyp")]
        public MeetingType MeetingType { get; set; }

        public ICollection<AvailableTimeSpan> ScheduledTimeSpans { get; set; }

        [Display(Name = "Veckor")]
        public int Weeks { get; set; }

        [Display(Name = "Önskat Antal Tillfällen")]
        public OccassionCount OccassionCount { get; set; }

        public bool MyProperty { get; set; }

        // Tema
        // Fri text
        // öppen för förslag
        // Länk till hemsida för inspiration angående teman
        // öppen för långsiktigt / flera teman

        // Om fysiskt,
        // kan elevgruppen göra besök (transport)
        // Ta emot elevgrupp



        public MatchCard PartyA { get; set; }
        public MatchCard PartyB { get; set; }

    }
}
